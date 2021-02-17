using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Transactions
    {
        public int voucherGen_id { get; set; }
        public string voucherStats { get; set; }
        public DateTime voucherExpiry { get; set; }
        public int confirmCode { get; set; }
        public int user_id { get; set; }
        public DateTime voucherDate { get; set; }
        public int voucherTotalCost { get; set; }
        public int voucherQuantity { get; set; }
        public string voucherName { get; set; }
        public string voucherCategory { get; set; }


        public Transactions()
        {
        }



        public Transactions(int vouchergenid, string voucherstats, DateTime voucherexpiry, int confirmcode, int id, DateTime voucherdate, int vouchertotalcost, int voucherquantity, string vouchername, string vouchercategory)
        {
            this.voucherGen_id = vouchergenid;
            this.voucherStats = voucherstats;
            this.voucherExpiry = voucherexpiry;
            this.confirmCode = confirmcode;
            this.user_id = id;
            this.voucherDate = voucherdate;
            this.voucherTotalCost = vouchertotalcost;
            this.voucherQuantity = voucherquantity;
            this.voucherName = vouchername;
            this.voucherCategory = vouchercategory;
        }

        public Transactions GetTransactionByid(string transId)
        {
            TransactionDAO dao = new TransactionDAO();
            return dao.SelectByAccount(transId);


        }
        public void insertTrans()
        {
            TransactionDAO dao = new TransactionDAO();
            dao.insertTransaction(this);
        }


        public List<Transactions> getTransaction(int userId)
        {
            TransactionDAO dao = new TransactionDAO();
            return dao.getTransactionById(userId);
        }



        public List<Transactions> getTransactionOldest(int userId)
        {
            TransactionDAO dao = new TransactionDAO();
            return dao.getTransactionByIdOldest(userId);
        }






        public void shopVerify(string shopCode)
        {
            TransactionDAO dao = new TransactionDAO();
            dao.shopUsed(shopCode);
        }
    }

    

}