using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.Common.Utils;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ComposerDetailsControl : BaseNopAdministrationUserControl
    {
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string ComposerID = ctrlComposerInfo.SaveInfo();
                    Response.Redirect("ComposerDetails.aspx?ComposerID=" + ComposerID, false);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                PersonBiz pBiz = new PersonBiz();
                pBiz.DeletePerson(this.ComposerId);

                Response.Redirect("Composers.aspx", false);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        public long ComposerId
        {
            get
            {
                return long.Parse(CommonHelper.QueryStringInt("ComposerId").ToString());
            }
        }
    }
}