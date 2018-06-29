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
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Configuration.Provider;
using System.Configuration;
using System.Web.Hosting;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace NopSolutions.NopCommerce.DataAccess.Messages
{
    /// <summary>
    /// Acts as a base class for deriving custom message template provider
    /// </summary>
    [DBProviderSectionName("nopDataProviders/MessageProvider")]
    public abstract partial class DBMessageProvider : BaseDBProvider
    {
        #region Methods

        /// <summary>
        /// Gets a message template by template identifier
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <returns>Message template</returns>
        public abstract DBMessageTemplate GetMessageTemplateById(int messageTemplateId);

        /// <summary>
        /// Gets all message templates
        /// </summary>
        /// <returns>Message template collection</returns>
        public abstract DBMessageTemplateCollection GetAllMessageTemplates();

        /// <summary>
        /// Gets a localized message template by identifier
        /// </summary>
        /// <param name="localizedMessageTemplateId">Localized message template identifier</param>
        /// <returns>Localized message template</returns>
        public abstract DBLocalizedMessageTemplate GetLocalizedMessageTemplateById(int localizedMessageTemplateId);

        /// <summary>
        /// Gets a localized message template by name and language identifier
        /// </summary>
        /// <param name="name">Message template name</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Localized message template</returns>
        public abstract DBLocalizedMessageTemplate GetLocalizedMessageTemplate(string name, 
            int languageId);

        /// <summary>
        /// Deletes a localized message template
        /// </summary>
        /// <param name="localizedMessageTemplateId">Message template identifier</param>
        public abstract void DeleteLocalizedMessageTemplate(int localizedMessageTemplateId);

        /// <summary>
        /// Gets all localized message templates
        /// </summary>
        /// <param name="messageTemplateName">Message template name</param>
        /// <returns>Localized message template collection</returns>
        public abstract DBLocalizedMessageTemplateCollection GetAllLocalizedMessageTemplates(string messageTemplateName);

        /// <summary>
        /// Inserts a localized message template
        /// </summary>
        /// <param name="messageTemplateId">The message template identifier</param>
        /// <param name="languageId">The language identifier</param>
        /// <param name="bccEmailAddresses">The BCC Email addresses</param>
        /// <param name="subject">The subject</param>
        /// <param name="body">The body</param>
        /// <param name="isActive">A value indicating whether the message template is active</param>
        /// <returns>Localized message template</returns>
        public abstract DBLocalizedMessageTemplate InsertLocalizedMessageTemplate(int messageTemplateId,
            int languageId, string bccEmailAddresses, string subject, string body, bool isActive);

        /// <summary>
        /// Updates the localized message template
        /// </summary>
        /// <param name="messageTemplateLocalizedId">The localized message template identifier</param>
        /// <param name="messageTemplateId">The message template identifier</param>
        /// <param name="languageId">The language identifier</param>
        /// <param name="bccEmailAddresses">The BCC Email addresses</param>
        /// <param name="subject">The subject</param>
        /// <param name="body">The body</param>
        /// <param name="isActive">A value indicating whether the message template is active</param>
        /// <returns>Localized message template</returns>
        public abstract DBLocalizedMessageTemplate UpdateLocalizedMessageTemplate(int messageTemplateLocalizedId,
            int messageTemplateId, int languageId, string bccEmailAddresses, 
            string subject, string body, bool isActive);

        /// <summary>
        /// Gets a queued email by identifier
        /// </summary>
        /// <param name="queuedEmailId">Email item identifier</param>
        /// <returns>Email item</returns>
        public abstract DBQueuedEmail GetQueuedEmailById(int queuedEmailId);

        /// <summary>
        /// Deletes a queued email
        /// </summary>
        /// <param name="queuedEmailId">Email item identifier</param>
        public abstract void DeleteQueuedEmail(int queuedEmailId);

        /// <summary>
        /// Gets all queued emails
        /// </summary>
        /// <param name="fromEmail">From Email</param>
        /// <param name="toEmail">To Email</param>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="queuedEmailCount">Email item count. 0 if you want to get all items</param>
        /// <param name="loadNotSentItemsOnly">A value indicating whether to load only not sent emails</param>
        /// <param name="maxSendTries">Maximum send tries</param>
        /// <returns>Email item collection</returns>
        public abstract DBQueuedEmailCollection GetAllQueuedEmails(string fromEmail,
            string toEmail, DateTime? startTime, DateTime? endTime,
            int queuedEmailCount, bool loadNotSentItemsOnly, int maxSendTries);

        /// <summary>
        /// Inserts a queued email
        /// </summary>
        /// <param name="priority">The priority</param>
        /// <param name="from">From</param>
        /// <param name="fromName">From name</param>
        /// <param name="to">To</param>
        /// <param name="toName">To name</param>
        /// <param name="cc">Cc</param>
        /// <param name="bcc">Bcc</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="createdOn">The date and time of item creation</param>
        /// <param name="sendTries">The send tries</param>
        /// <param name="sentOn">The sent date and time. Null if email is not sent yet</param>
        /// <returns>Queued email</returns>
        public abstract DBQueuedEmail InsertQueuedEmail(int priority, string from,
            string fromName, string to, string toName, string cc, string bcc,
            string subject, string body, DateTime createdOn, int sendTries, DateTime? sentOn);

        /// <summary>
        /// Updates a queued email
        /// </summary>
        /// <param name="queuedEmailId">Email item identifier</param>
        /// <param name="priority">The priority</param>
        /// <param name="from">From</param>
        /// <param name="fromName">From name</param>
        /// <param name="to">To</param>
        /// <param name="toName">To name</param>
        /// <param name="cc">Cc</param>
        /// <param name="bcc">Bcc</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="createdOn">The date and time of item creation</param>
        /// <param name="sendTries">The send tries</param>
        /// <param name="sentOn">The sent date and time. Null if email is not sent yet</param>
        /// <returns>Queued email</returns>
        public abstract DBQueuedEmail UpdateQueuedEmail(int queuedEmailId, 
            int priority, string from,
            string fromName, string to, string toName, string cc, string bcc,
            string subject, string body, DateTime createdOn, int sendTries, DateTime? sentOn);

        /// <summary>
        /// Inserts the new newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscriptionGuid">The newsletter subscription GUID</param>
        /// <param name="email">The subscriber email</param>
        /// <param name="isActive">A value indicating whether subscription is active</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>NewsLetterSubscription entity</returns>
        public abstract DBNewsLetterSubscription InsertNewsLetterSubscription(Guid newsLetterSubscriptionGuid, 
            string email, bool isActive, DateTime createdOn);

        /// <summary>
        /// Gets the newsletter subscription by newsletter subscription identifier
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The newsletter subscription identifier</param>
        /// <returns>NewsLetterSubscription entity</returns>
        public abstract DBNewsLetterSubscription GetNewsLetterSubscriptionById(int newsLetterSubscriptionId);

        /// <summary>
        /// Gets the newsletter subscription by newsletter subscription GUID
        /// </summary>
        /// <param name="newsLetterSubscriptionGuid">The newsletter subscription GUID</param>
        /// <returns>NewsLetterSubscription entity</returns>
        public abstract DBNewsLetterSubscription GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid);

        /// <summary>
        /// Gets the newsletter subscription by email
        /// </summary>
        /// <param name="email">The Email</param>
        /// <returns>NewsLetterSubscription entity</returns>
        public abstract DBNewsLetterSubscription GetNewsLetterSubscriptionByEmail(string email);

        /// <summary>
        /// Gets the newsletter subscription collection
        /// </summary>
        /// <param name="showHidden">A value indicating whether the not active subscriptions should be loaded</param>
        /// <returns>NewsLetterSubscription entity collection</returns>
        public abstract DBNewsLetterSubscriptionCollection GetAllNewsLetterSubscriptions(bool showHidden);

        /// <summary>
        /// Updates the newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The newsletter subscription identifier</param>
        /// <param name="newsLetterSubscriptionGuid">The newsletter subscription GUID</param>
        /// <param name="email">The subscriber email</param>
        /// <param name="isActive">A value indicating whether subscription is active</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>NewsLetterSubscription entity</returns>
        public abstract DBNewsLetterSubscription UpdateNewsLetterSubscription(int newsLetterSubscriptionId, 
            Guid newsLetterSubscriptionGuid, string email, bool isActive, DateTime createdOn);

        /// <summary>
        /// Deletes the newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The newsletter subscription identifier</param>
        public abstract void DeleteNewsLetterSubscription(int newsLetterSubscriptionId);
        #endregion
    }
}

