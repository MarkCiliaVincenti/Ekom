﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uWebshop.Interfaces;

namespace uWebshop.Models
{
    public class OrderLine : IOrderLine
    {
        private Guid _productId;
        private IEnumerable<Guid> _variantIds;
        private StoreInfo _storeInfo;

        public Guid Id { get; set; }
        public OrderedProduct Product { get; set; }
        public int Quantity { get; set; }

        public IDiscountedPrice Amount
        {
            get
            {
                return new Price(Product.OriginalPrice * Quantity, _storeInfo);
            }
        }
        public OrderLine(Guid lineId, int quantity, string productJson, StoreInfo storeInfo)
        {
            Id = lineId;
            Quantity = quantity;
            _storeInfo = storeInfo;
            Product = new OrderedProduct(productJson, storeInfo);
        }

        public OrderLine(Guid productId, IEnumerable<Guid> variantIds, int quantity, Guid lineId, Store store)
        {
            _productId = productId;
            _variantIds = variantIds;
            _storeInfo = new StoreInfo(store);
            Quantity = quantity;
            Id = lineId;
            Product = new OrderedProduct(productId, variantIds, store);
        }


    }
}