using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core.Models
{
    public static class CardActivityType
    {
        public static string Add    = "ADD_CARD";
        public static string Move   = "MOVE_CARD";
        public static string Modify = "MODIFY_CARD";
        public static string Delete = "DELETE_CARD";
        public static string None   = String.Empty;
    }

    public class CardActivity
    {
        public int ID { get; set; }
        public DateTime LoggedDate { get; set; }
        public string LoggedUser { get; set; }
        public string ActivityType { get; set; }
    }
}
