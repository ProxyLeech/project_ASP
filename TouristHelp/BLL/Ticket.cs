using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string attractionName { get; set; }
        public string attractionDesc { get; set; }
        public double price { get; set; }
        public DateTime dateExpire { get; set; }
        public string ticketCode { get; set; }
        public string paid { get; set; }
        public int userId { get; set; }
        public string ticketImage { get; set; }
        public int cartId { get; set; }

        public Ticket()
        {

        }

        public Ticket(string attName, string attDesc, double attPrice, DateTime expDate, string attCode, string statPaid, int user_id, int cart_id, string attImg)
        {
            attractionName = attName;
            attractionDesc = attDesc;
            price = attPrice;
            dateExpire = expDate;
            ticketCode = attCode;
            paid = statPaid;
            userId = user_id;
            cartId = cart_id;
            ticketImage = attImg;
        }

        public Ticket(int attId, string attName, string attDesc, DateTime expDate, string attCode, string attImg)
        {
            ticketId = attId;
            attractionName = attName;
            attractionDesc = attDesc;
            dateExpire = expDate;
            ticketCode = attCode;
            ticketImage = attImg;
        }

        public Ticket(string attName, string attDesc, double attPrice, DateTime expDate, int user_id, string attImg)
        {

            attractionName = attName;
            attractionDesc = attDesc;
            price = attPrice;
            dateExpire = expDate;
            userId = user_id;
            ticketImage = attImg;

        }

        public void AddNewTicket()
        {
            TicketDAO tkt = new TicketDAO();
            tkt.AddTicket(this);
        }

        public List<Ticket> GetAllTicket(int user_id)
        {
            TicketDAO tkt = new TicketDAO();
            return tkt.SelectTicketByUser(user_id);
        }

        public List<String> GetCodes()
        {
            TicketDAO cdList = new TicketDAO();
            return cdList.GetAllCode();
        }

        public Ticket getTicketDetail(int cart_id, int user_id)
        {
            TicketDAO tkt = new TicketDAO();
            return tkt.GetTicketItem(cart_id, user_id);
        }

        public void TicketPay(int cartId, int userId)
        {
            TicketDAO dao = new TicketDAO();
            dao.UpdateTicket(cartId, userId);
        }

        public Ticket getTicketById(int ticketId)
        {
            TicketDAO dao = new TicketDAO();
            return dao.GetTicketById(ticketId);
        }

        public void ClaimTicket(string ticketCode)
        {
            TicketDAO dao = new TicketDAO();
            dao.ClaimTicket(ticketCode);
        }

        public void TicketExpire(int ticketId)
        {
            TicketDAO dao = new TicketDAO();
            dao.TicketExp(ticketId);
        }
    }
}