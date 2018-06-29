//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Content.Topics;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class TopicInfoControl : BaseNopAdministrationUserControl
    {
        private void BindData()
        {
            Topic topic = TopicManager.GetTopicById(this.TopicId);
            if (topic != null)
            {
                this.txtName.Text = topic.Name;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        public Topic SaveInfo()
        {
            Topic topic = TopicManager.GetTopicById(this.TopicId);
            if (topic != null)
            {
                topic = TopicManager.UpdateTopic(topic.TopicId, txtName.Text);
            }
            else
            {
                topic = TopicManager.InsertTopic(txtName.Text);
            }

            return topic;
        }

        public int TopicId
        {
            get
            {
                return CommonHelper.QueryStringInt("TopicId");
            }
        }
    }
}