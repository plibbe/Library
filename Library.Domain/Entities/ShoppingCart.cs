using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class ShoppingCart : TableEntity
    {
        public ShoppingCart() { }

        public ShoppingCart(string id, string cart)
        {
            PartitionKey = id;
            RowKey = cart;
        }
    }
}
