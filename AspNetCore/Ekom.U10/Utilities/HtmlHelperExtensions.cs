//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Umbraco.Extensions;

//namespace Ekom.U10.Utilities
//{
//    public static class HtmlHelperExtensions
//    {
//        /// <summary>
//        /// Render an Ekom form that submits to the <see cref="OrderController"/>
//        /// Placing html inside using construct.
//        /// </summary>
//        /// <param name="htmlHelper"></param>
//        /// <param name="formType"></param>
//        /// <param name="className">Override the default Ekom classnames</param>
//        /// <returns></returns>
//        /// <example>
//        /// using (Html.BeginEkomForm(FormType.UpdatePaymentProvider)) 
//        /// {
//        ///     <input type="hidden" name="input" value="value" />
//        ///     <button type = "submit" class="button">Submit</button>            
//        /// }
//        /// </example>
//        public static MvcForm BeginEkomForm(this HtmlHelper htmlHelper, FormType formType, string className = null, string Id = null)
//        {
//            var actionName = formType.ToString();
//            var defaultClassName = "";

//            switch (formType)
//            {
//                case FormType.AddToOrderProduct:

//                    actionName = "AddToOrder";
//                    defaultClassName = "product__form";
//                    break;

//                case FormType.AddToOrderCart:

//                    actionName = "AddToOrder";
//                    defaultClassName = "cart__quantity-form";
//                    break;
//                case FormType.UpdateOrderLineQuantity:

//                    actionName = "UpdateOrderlineQuantity";
//                    defaultClassName = "cart__quantity-form";
//                    break;
//                case FormType.RemoveOrderLine:

//                    defaultClassName = "cart__remove-form";
//                    break;

//                case FormType.UpdatePaymentProvider:

//                    defaultClassName = "cart__payment-form";
//                    break;

//                case FormType.UpdateShippingProvider:

//                    defaultClassName = "cart__shipping-form";
//                    break;

//                case FormType.UpdateCustomerInformation:

//                    defaultClassName = "cart__quantity-form";
//                    break;
//                case FormType.ApplyCouponToOrder:

//                    defaultClassName = "cart__coupon-form";
//                    break;
//                case FormType.ChangeCurrency:

//                    defaultClassName = "order__changeCurrency-form";
//                    break;
//            }

//            className = className ?? defaultClassName;

//            return htmlHelper.BeginUmbracoForm<Ekom.Controllers.EkomOrderController>(actionName, null, new { @class = className, @id = Id });
//        }
//    }


//}