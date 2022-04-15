using System;
using System.Text.Json.Serialization;
using bookstore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace bookstore.Models
{
	public class SessionCart : Cart
	{

        public static Cart GetCart (IServiceProvider svc)
        {
            ISession session = svc.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;

            return cart;
        }

		[JsonIgnore]
		public ISession Session { get; set; }

        private void UpdateCartInSession()
        {
            Session.SetJson("Cart", this);
        }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            UpdateCartInSession();
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            UpdateCartInSession();
        }

        public override void DecrementQty(Book book)
        {
            base.DecrementQty(book);
            UpdateCartInSession();
        }

        public override void ClearCart()
        {
            base.ClearCart();
            UpdateCartInSession();
        }

    }
}

