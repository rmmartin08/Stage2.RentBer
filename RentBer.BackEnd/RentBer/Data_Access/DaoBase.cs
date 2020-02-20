using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LiteDB;

namespace RentBer.Data_Access
{
    public abstract class DaoBase
    {
        private static object lockObj { get; set; } = new { };
        protected static LiteDatabase db { get; set; }
        private const string GrillBerDBLocation = @"C:\RentBer\Rentber.db";

        public DaoBase()
        {
            var grillberDBDir = Path.GetDirectoryName(GrillBerDBLocation);
            if (grillberDBDir != null && !Directory.Exists(grillberDBDir))
            {
                Directory.CreateDirectory(grillberDBDir);
            }

            lock (lockObj)
            {
                if (db == null)
                {
                    db = new LiteDatabase(GrillBerDBLocation);
                }
            }
        }

        public static bool DisposeOfDb()
        {
            db.Dispose();
            db = null;
            return true;
        }
    }
}