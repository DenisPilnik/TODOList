using System;
using System.Collections.Generic;
using System.Linq;
using TODO_List.Models;
using VelocityDb.Session;


namespace TODO_List.DataBase
{
    public static class VelocityWorker
    {
        static readonly string systemDir = "TODOList"; // appended to SessionBase.BaseDatabasePath

        public static void AddNewTask(Chalange chalange)
        {
            using(SessionNoServer session = new SessionNoServer(systemDir))
            {
                try {
                    session.BeginUpdate();
                    session.Persist(chalange);
                    session.Commit();
                }
                catch (Exception)
                {
                    session.Abort();
                }
            }
        }
        public static List<Chalange> GetChalangeFromDb()
        {
            List<Chalange> chalanges = new List<Chalange>();
            using (SessionNoServer session = new SessionNoServer(systemDir))
            {
                try
                {
                    session.BeginRead();
                    chalanges = session.AllObjects<Chalange>().ToList();
                    session.Commit();
                }
                catch (Exception)
                {
                    session.Abort();
                }
            }
            chalanges.Sort((x, y) => x.Id.CompareTo(y.Id));
            return chalanges;
        }
        public static void DeleteChalangeFromDb(Chalange chalange)
        {
            using (SessionNoServer session = new SessionNoServer(systemDir))
            {
                try
                {
                    session.BeginUpdate();
                    session.DeleteObject(session.AllObjects<Chalange>().ToList().First(x => x.TaskName == chalange.TaskName).Id);
                    session.Commit();
                }
                catch (Exception)
                {
                    session.Abort();
                }
            }
        }
        public static void UpdateChalangeList(List<Chalange> chalanges)
        {
            using (SessionNoServer session = new SessionNoServer(systemDir))
            {
                try
                {
                    session.TraceIndexUsage = true;
                    session.BeginUpdate();
                    foreach(Chalange chalange in chalanges)
                    {                       
                        Chalange ch = (from aChalange in session.AllObjects<Chalange>() where aChalange.TaskName == chalange.TaskName select aChalange ).First();
                        ch.TaskСompleteness = chalange.TaskСompleteness;
                        session.UpdateObject(ch);
                    }
                    session.Commit();
                }
                catch (Exception)
                {
                    session.Abort();
                }
            }
        }
        public static void EditChalange(string taskString, Chalange chalange)
        {
            using(SessionNoServer session = new SessionNoServer(systemDir))
            {
                try
                {
                    session.TraceIndexUsage = true;
                    session.BeginUpdate();
                    Chalange ch = (from aChalange in session.AllObjects<Chalange>() where aChalange.TaskName == chalange.TaskName select aChalange).First();
                    ch.TaskName = taskString;
                    session.UpdateObject(ch);
                    session.Commit();
                }
                catch (Exception)
                {
                    session.Abort();
                }
            }
        }
    }
}
