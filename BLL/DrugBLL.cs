﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class DrugBLL
    {
        IDAL.IDrugDAL iDrug = DALFactory.DataAccess.CreateDrugDAL();
        private static DrugBLL instance;

        private DrugBLL()
        {
        }

        public static DrugBLL GetDrugBLLL()
        {
            if (instance == null)
            {
                instance = new DrugBLL();
            }
            return instance;
        }
        
        public DataTable GetAllDrug()
        {
            return iDrug.GetDrugDataList();
        }

        public DataTable GetDrugsByAB(string ab)
        {
            return iDrug.FindDrugByAB(ab);
        }

        public DataTable GetDrugsByName(string name)
        {
            return iDrug.FindDrugByName(name);
        }

        public double GetDrugsCount()
        {
            return iDrug.GetDurgsCount();
        }

        public bool DeleteById(int drug_id, out string msg)
        {
            msg = "删除成功！";
            try
            {
                iDrug.DeleteByID(drug_id);
            }
            catch (Exception exp)
            {
                msg = exp.Message;
                return false;
            }
            return true;
        }

        public int GetDrugTypeCount()
        {
            try
            {
                return iDrug.GetDrugTypeCount();
            }
            catch (Exception exp)
            {
                return -1;
            }
        }

        public bool AddDrug(Model.Drug drug,out string msg)
        {
            try
            {
                iDrug.Add(drug);
            }
            catch (Exception exp)
            {
                msg = exp.Message;
                return false;
            }
            msg = "成功";
            return true;
        }
    }
}
