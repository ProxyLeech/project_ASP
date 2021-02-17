using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Logs
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public Logs()
        {
        }

        public Logs(string target, string type, string content, DateTime dateTime)// for adding
        {
            Target = target;
            Type = type;
            Content = content;
            DateTime = dateTime;
        }

        public Logs(int id, string target, string type, string content, DateTime dateTime)// for getting
        {
            Id = id;
            Target = target;
            Type = type;
            Content = content;
            DateTime = dateTime;
        }

        public List<Logs> GetAllLogs(bool newFirst)
        {
            LogsDAO dao = new LogsDAO();
            return dao.SelectAll(newFirst);
        }

        public List<Logs> GetFilteredLogs(string target, string type, DateTime? time1, DateTime? time2, string key, bool newFirst)
        {
            LogsDAO dao = new LogsDAO();
            return dao.SelectFiltered(target, type, time1, time2, key, newFirst);
        }

        public void AddLogs(Logs log)
        {
            LogsDAO dao = new LogsDAO();
            dao.InsertNewLog(log);
        }

        public int GetChartData(string type, string target)
        {
            LogsDAO dao = new LogsDAO();
            return dao.SelectLogsForChart(type, target); ;
        }
    }
}