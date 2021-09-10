using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TODO_List.Models;
using VelocityDb;
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
            return chalanges;
        }
        public static void DeleteChalangeFromDb(Chalange chalange)
        {
            //TODO Создать систему id
            using(SessionNoServer session = new SessionNoServer(systemDir))
            {
                try
                {
                    session.BeginUpdate();
                    session.DeleteObject((ulong)session.AllObjects<Chalange>().ToList().IndexOf();
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
