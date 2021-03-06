﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class Bank : IEnumerable, IEnumerator
	{
		public List<BaseClient> Clients = new List<BaseClient>();
		public List<ITransaction> Transaction = new List<ITransaction>();

        public string path = @"Log.txt";
        //--------------------------------------------------------------
        public void SaveTransaction()
        { 
			if (!File.Exists(path))
				File.Create(path);
			else
			{
				using (StreamWriter sw = new StreamWriter(path))
				{
					foreach (var item in Transaction)
					{
						sw.WriteLine($"Date: {item.DT} Amount: {item.Amount}");
					}
				}
			}
		}
		//--------------------------------------------------------------
		int current = -1;

		public object Current => Clients[current];

        public IEnumerator GetEnumerator()
		{
			return (IEnumerator)this;
		}

		public bool MoveNext()
		{
			current++;
			return current < Clients.Count;
		}

		public void Reset()
		{
			current = -1;
		}
        //--------------------------------------------------------------
        public void PercentInvoke()
        {
            PercentUp.Invoke();
        }
        //--------------------------------------------------------------
        public void BankrotInvoke()
        {
            Bankrot.Invoke();
        }
        //--------------------------------------------------------------
        public delegate void BankOperation();
		public event BankOperation Bankrot;
		public event BankOperation PercentUp;
    }
}
//--------------------------------------------------------------