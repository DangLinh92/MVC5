using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAdmin.Models
{
    public class DataProvider
    {

        /// <summary>
        /// Khai báo 1 đối tượng để kết nối với db cần làm việc qua EF
        /// </summary>
        private static BookStoreModel _Entities = null;

        public static BookStoreModel Entities
        {
            get => _Entities ?? (_Entities = new BookStoreModel());

            set => _Entities = value;
        }
    }
}