using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAdmin.Models
{
    public class DataProvider
    {
        private static readonly BookStoreModel BookStore = null;

        public static BookStoreModel EntityModel => BookStore ?? new BookStoreModel();
    }
}