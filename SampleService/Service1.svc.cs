using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.ServiceModel.Activation;

namespace SampleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode= AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public List<clsListdata> GetdataJSON(string value)
        {
            List<clsListdata> lstdata = new List<clsListdata>();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Rows.Add("1", "Devan");
                dt.Rows.Add("2", "Irfan");
                dt.Rows.Add("3", "Guru");
                dt.Rows.Add("4", "Tamil");
                dt.Rows.Add("5", "Shankar");

                if (value.ToLower() == "all")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        clsListdata clsdata = new clsListdata();
                        clsdata.ID = dt.Rows[i]["ID"].ToString();
                        clsdata.Name = dt.Rows[i]["Name"].ToString();
                        clsdata.ErrorMessage = "";
                        lstdata.Add(clsdata);
                    }
                }
                else
                {
                    DataTable dtfilter = new DataTable();
                    DataRow[] dr;
                    dr = dt.Select("ID='" + value + "'");
                    if (dr.Length > 0)
                    {
                        clsListdata clsdata = new clsListdata();
                        clsdata.ID = dr[0].ItemArray[0].ToString(); 
                        clsdata.Name = dr[0].ItemArray[1].ToString();
                        clsdata.ErrorMessage = "";
                        lstdata.Add(clsdata);
                    }
                    else
                    {
                        clsListdata clsdata = new clsListdata();
                        clsdata.ID = "";
                        clsdata.Name = "";
                        clsdata.ErrorMessage = "No Record Found..";
                        lstdata.Add(clsdata);
                    }
                }
            }   
            catch(Exception ex)
            {
                clsListdata clsdata = new clsListdata();
                clsdata.ID = "";
                clsdata.Name = "";
                clsdata.ErrorMessage = ex.Message.ToString();
                lstdata.Add(clsdata);
            }
            return lstdata;
        }

        public List<clsLeadDataSuccess> PostdataJSON(clsListdata p)
        {
            try
            {
                List<clsLeadDataSuccess> lst = new List<clsLeadDataSuccess>();
                clsLeadDataSuccess cls = new clsLeadDataSuccess();
                cls.SuccessMessage = p.imgString;
                cls.ErrorMessage = "";
                lst.Add(cls);
                return lst;
            }
            catch (Exception ex)
            {
                List<clsLeadDataSuccess> lst = new List<clsLeadDataSuccess>();
                clsLeadDataSuccess cls = new clsLeadDataSuccess();
                cls.SuccessMessage = "";
                cls.ErrorMessage = ex.Message.ToString();
                lst.Add(cls);
                return lst;
            }
        }

        }
}
