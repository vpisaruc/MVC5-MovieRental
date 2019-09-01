using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }    
        public short SingUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // чтобы сделать код более читабельным добавим несколько вспомогательных переменных
        // если тип подписки не поределен
        public static readonly byte Unknown = 0;
        // если выбран PayAsYouGo тип подписки
        public static readonly byte PayAsYouGo = 1;
    }
}