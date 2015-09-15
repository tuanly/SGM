using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGM.ServicesCore.DTO
{
    class CustomerDTO
    {
        private string m_iCustomerID;      
        private string m_stCustomerName;
        private string m_stCustomerVisa; //cmnd or visa
        private string m_dCustomerBirthDate;
        private string m_stCustomerAddress;
        private string m_stCustomerPhone;
        private string m_stCustomerNote;

        public CustomerDTO()
        {
            m_iCustomerID = "";           
            m_stCustomerName = "";
            m_stCustomerVisa = "";
            m_dCustomerBirthDate = "";
            m_stCustomerAddress = "";
            m_stCustomerPhone = "";
            m_stCustomerNote = "";
        }

        public string CustomerID
        {
            get { return m_iCustomerID; }
            set { m_iCustomerID = value; }
        }

        public string CustomerName
        {
            get { return m_stCustomerName; }
            set { m_stCustomerName = value; }
        }

        public string CustomerVisa
        {
            get { return m_stCustomerVisa; }
            set { m_stCustomerVisa = value; }
        }

        public string CustomerBirthDate
        {
            get { return m_dCustomerBirthDate; }
            set { m_dCustomerBirthDate = value; }
        }

        public string CustomerAddress
        {
            get { return m_stCustomerAddress; }
            set { m_stCustomerAddress = value; }
        }

        public string CustomerPhone
        {
            get { return m_stCustomerPhone; }
            set { m_stCustomerPhone = value; }
        }

        public string CustomerNote
        {
            get { return m_stCustomerNote; }
            set { m_stCustomerNote = value; }
        }
    }
}
