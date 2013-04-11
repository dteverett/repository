using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;

namespace WebTester
{
    public class WebForms : IWebForms
    {
        private long _parentTestID;

        public const string defaultPassword = "hedge1!";
        private long _testID;
        

        public virtual TestResults Execute(WebForms form)
        {
            throw new NotImplementedException();
        }
        public virtual TestResults Execute(WebForms form, long parentTestID)
        {
            throw new NotImplementedException();
        }

        public long TestID
        {
            get { return _testID; }
            set { _testID = value; }
        }

        public long ParentTestID
        {
            get {return _parentTestID;}
            set {_parentTestID = value;}
        }

        public string ClientID
        {
            get { return this.client.ClientID; }
            set { this.client.ClientID = value; }
        }

        public TestResults testResults { get; set; }

        public Client client { get; set; }

        public WebForms()
        {
        }

        public WebForms(Client client)
        {
            this.client = client;
            this.testResults = new TestResults();
        }
    }
}
