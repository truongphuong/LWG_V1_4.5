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
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Web;
using NopSolutions.NopCommerce.BusinessLogic.Caching;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.CustomerManagement;
using NopSolutions.NopCommerce.BusinessLogic.Messages;
using NopSolutions.NopCommerce.BusinessLogic.Profile;
using NopSolutions.NopCommerce.BusinessLogic.Utils.Html;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.Common.Utils.Html;
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Content.Forums;

namespace NopSolutions.NopCommerce.BusinessLogic.Content.Forums
{
    /// <summary>
    /// Forum manager
    /// </summary>
    public partial class ForumManager
    {
        #region Constants
        private const string FORUMGROUP_ALL_KEY = "Nop.forumgroup.all";
        private const string FORUMGROUP_BY_ID_KEY = "Nop.forumgroup.id-{0}";
        private const string FORUM_ALLBYFORUMGROUPID_KEY = "Nop.forum.allbyforumgroupid-{0}";
        private const string FORUM_BY_ID_KEY = "Nop.forum.id-{0}";
        private const string FORUMGROUP_PATTERN_KEY = "Nop.forumgroup.";
        private const string FORUM_PATTERN_KEY = "Nop.forum.";
        #endregion

        #region Utilities
        private static ForumGroupCollection DBMapping(DBForumGroupCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new ForumGroupCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static ForumGroup DBMapping(DBForumGroup dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new ForumGroup();
            item.ForumGroupId = dbItem.ForumGroupId;
            item.Name = dbItem.Name;
            item.Description = dbItem.Description;
            item.DisplayOrder = dbItem.DisplayOrder;
            item.CreatedOn = dbItem.CreatedOn;
            item.UpdatedOn = dbItem.UpdatedOn;

            return item;
        }

        private static ForumCollection DBMapping(DBForumCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new ForumCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static Forum DBMapping(DBForum dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new Forum();
            item.ForumId = dbItem.ForumId;
            item.ForumGroupId = dbItem.ForumGroupId;
            item.Name = dbItem.Name;
            item.Description = dbItem.Description;
            item.NumTopics = dbItem.NumTopics;
            item.NumPosts = dbItem.NumPosts;
            item.LastTopicId = dbItem.LastTopicId;
            item.LastPostId = dbItem.LastPostId;
            item.LastPostUserId = dbItem.LastPostUserId;
            item.LastPostTime = dbItem.LastPostTime;
            item.DisplayOrder = dbItem.DisplayOrder;
            item.CreatedOn = dbItem.CreatedOn;
            item.UpdatedOn = dbItem.UpdatedOn;

            return item;
        }

        private static ForumTopicCollection DBMapping(DBForumTopicCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new ForumTopicCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static ForumTopic DBMapping(DBForumTopic dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new ForumTopic();
            item.ForumTopicId = dbItem.ForumTopicId;
            item.ForumId = dbItem.ForumId;
            item.UserId = dbItem.UserId;
            item.TopicTypeId = dbItem.TopicTypeId;
            item.Subject = dbItem.Subject;
            item.NumPosts = dbItem.NumPosts;
            item.Views = dbItem.Views;
            item.LastPostId = dbItem.LastPostId;
            item.LastPostUserId = dbItem.LastPostUserId;
            item.LastPostTime = dbItem.LastPostTime;
            item.CreatedOn = dbItem.CreatedOn;
            item.UpdatedOn = dbItem.UpdatedOn;

            return item;
        }

        private static ForumPostCollection DBMapping(DBForumPostCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new ForumPostCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static ForumPost DBMapping(DBForumPost dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new ForumPost();
            item.ForumPostId = dbItem.ForumPostId;
            item.TopicId = dbItem.TopicId;
            item.UserId = dbItem.UserId;
            item.Text = dbItem.Text;
            item.IPAddress = dbItem.IPAddress;
            item.CreatedOn = dbItem.CreatedOn;
            item.UpdatedOn = dbItem.UpdatedOn;

            return item;
        }

        private static PrivateMessageCollection DBMapping(DBPrivateMessageCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new PrivateMessageCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static PrivateMessage DBMapping(DBPrivateMessage dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new PrivateMessage();
            item.PrivateMessageId = dbItem.PrivateMessageId;
            item.FromUserId = dbItem.FromUserId;
            item.ToUserId = dbItem.ToUserId;
            item.Subject = dbItem.Subject;
            item.Text = dbItem.Text;
            item.IsRead = dbItem.IsRead;
            item.IsDeletedByAuthor = dbItem.IsDeletedByAuthor;
            item.IsDeletedByRecipient = dbItem.IsDeletedByRecipient;
            item.CreatedOn = dbItem.CreatedOn;

            return item;
        }

        private static ForumSubscriptionCollection DBMapping(DBForumSubscriptionCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new ForumSubscriptionCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static ForumSubscription DBMapping(DBForumSubscription dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new ForumSubscription();
            item.ForumSubscriptionId = dbItem.ForumSubscriptionId;
            item.SubscriptionGuid = dbItem.SubscriptionGuid;
            item.UserId = dbItem.UserId;
            item.ForumId = dbItem.ForumId;
            item.TopicId = dbItem.TopicId;
            item.CreatedOn = dbItem.CreatedOn;

            return item;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deletes a forum group
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        public static void DeleteForumGroup(int forumGroupId)
        {
            DBProviderManager<DBForumProvider>.Provider.DeleteForumGroup(forumGroupId);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a forum group
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forum group</returns>
        public static ForumGroup GetForumGroupById(int forumGroupId)
        {
            if (forumGroupId == 0)
                return null;

            string key = string.Format(FORUMGROUP_BY_ID_KEY, forumGroupId);
            object obj2 = NopCache.Get(key);
            if (ForumManager.CacheEnabled && (obj2 != null))
            {
                return (ForumGroup)obj2;
            }
            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetForumGroupById(forumGroupId);
            var forumGroup = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.Max(key, forumGroup);
            }
            return forumGroup;
        }

        /// <summary>
        /// Gets all forum groups
        /// </summary>
        /// <returns>Forum groups</returns>
        public static ForumGroupCollection GetAllForumGroups()
        {
            string key = string.Format(FORUMGROUP_ALL_KEY);
            object obj2 = NopCache.Get(key);
            if (ForumManager.CacheEnabled && (obj2 != null))
            {
                return (ForumGroupCollection)obj2;
            }
            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllForumGroups();
            var forumGroupCollection = DBMapping(dbCollection);

            if (ForumManager.CacheEnabled)
            {
                NopCache.Max(key, forumGroupCollection);
            }
            return forumGroupCollection;
        }

        /// <summary>
        /// Inserts a forum group
        /// </summary>
        /// <param name="name">The language name</param>
        /// <param name="description">The description</param>
        /// <param name="displayOrder">The display order</param>        
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Forum group</returns>
        public static ForumGroup InsertForumGroup(string name, string description,
            int displayOrder, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertForumGroup(name, 
                description, displayOrder, createdOn, updatedOn);

            var forumGroup = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forumGroup;
        }

        /// <summary>
        /// Updates the forum group
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <param name="name">The language name</param>
        /// <param name="description">The description</param>
        /// <param name="displayOrder">The display order</param>        
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Forum group</returns>
        public static ForumGroup UpdateForumGroup(int forumGroupId,
            string name, string description, int displayOrder,
            DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdateForumGroup(forumGroupId, 
                name, description, displayOrder, createdOn, updatedOn);

            var forumGroup = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forumGroup;
        }

        /// <summary>
        /// Deletes a forum
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        public static void DeleteForum(int forumId)
        {
            DBProviderManager<DBForumProvider>.Provider.DeleteForum(forumId);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a forum
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <returns>Forum</returns>
        public static Forum GetForumById(int forumId)
        {
            if (forumId == 0)
                return null;

            string key = string.Format(FORUM_BY_ID_KEY, forumId);
            object obj2 = NopCache.Get(key);
            if (ForumManager.CacheEnabled && (obj2 != null))
            {
                return (Forum)obj2;
            }
            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetForumById(forumId);
            var forum = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.Max(key, forum);
            }
            return forum;
        }

        /// <summary>
        /// Gets forums by group identifier
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forums</returns>
        public static ForumCollection GetAllForumsByGroupId(int forumGroupId)
        {
            string key = string.Format(FORUM_ALLBYFORUMGROUPID_KEY, forumGroupId);
            object obj2 = NopCache.Get(key);
            if (ForumManager.CacheEnabled && (obj2 != null))
            {
                return (ForumCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllForumsByGroupId(forumGroupId);
            var forumCollection = DBMapping(dbCollection);

            if (ForumManager.CacheEnabled)
            {
                NopCache.Max(key, forumCollection);
            }
            return forumCollection;
        }

        /// <summary>
        /// Inserts a forum
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <param name="name">The language name</param>
        /// <param name="description">The description</param>
        /// <param name="numTopics">The number of topics</param>
        /// <param name="numPosts">The number of posts</param>
        /// <param name="lastTopicId">The last topic identifier</param>
        /// <param name="lastPostId">The last post identifier</param>
        /// <param name="lastPostUserId">The last post user identifier</param>
        /// <param name="lastPostTime">The last post date and time</param>
        /// <param name="displayOrder">The display order</param>        
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Forum</returns>
        public static Forum InsertForum(int forumGroupId,
            string name, string description,
            int numTopics, int numPosts, int lastTopicId, int lastPostId,
            int lastPostUserId, DateTime? lastPostTime, int displayOrder,
            DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertForum(forumGroupId,
                name, description, numTopics, numPosts, lastTopicId, lastPostId,
                lastPostUserId, lastPostTime, displayOrder, createdOn, updatedOn);

            var forum = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forum;
        }

        /// <summary>
        /// Updates the forum
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <param name="name">The language name</param>
        /// <param name="description">The description</param>
        /// <param name="numTopics">The number of topics</param>
        /// <param name="numPosts">The number of posts</param>
        /// <param name="lastTopicId">The last topic identifier</param>
        /// <param name="lastPostId">The last post identifier</param>
        /// <param name="lastPostUserId">The last post user identifier</param>
        /// <param name="lastPostTime">The last post date and time</param>
        /// <param name="displayOrder">The display order</param>        
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Forum</returns>
        public static Forum UpdateForum(int forumId,
            int forumGroupId, string name, string description,
            int numTopics, int numPosts, int lastTopicId, int lastPostId,
            int lastPostUserId, DateTime? lastPostTime, int displayOrder,
            DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdateForum(forumId, 
                forumGroupId, name, description, numTopics, numPosts, 
                lastTopicId, lastPostId, lastPostUserId, lastPostTime, 
                displayOrder, createdOn, updatedOn);

            var forum = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forum;
        }

        /// <summary>
        /// Update forum stats
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <returns>Forum</returns>
        public static void UpdateForumStats(int forumId)
        {
            if (forumId == 0)
                return;

            DBProviderManager<DBForumProvider>.Provider.UpdateForumStats(forumId);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="forumTopicId">The topic identifier</param>
        public static void DeleteTopic(int forumTopicId)
        {
            DBProviderManager<DBForumProvider>.Provider.DeleteTopic(forumTopicId);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="forumTopicId">The topic identifier</param>
        /// <returns>Topic</returns>
        public static ForumTopic GetTopicById(int forumTopicId)
        {
            return GetTopicById(forumTopicId, false);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="forumTopicId">The topic identifier</param>
        /// <param name="increaseViews">The value indicating whether to increase topic views</param>
        /// <returns>Topic</returns>
        public static ForumTopic GetTopicById(int forumTopicId, bool increaseViews)
        {
            if (forumTopicId == 0)
                return null;

            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetTopicById(forumTopicId,
                increaseViews);
            var forumTopic = DBMapping(dbItem);

            return forumTopic;
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="forumId">The forum group identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchPosts">A value indicating whether to search in posts</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Topics</returns>
        public static ForumTopicCollection GetAllTopics(int forumId,
            int userId, string keywords, bool searchPosts, int pageSize,
            int pageIndex, out int totalRecords)
        {
            if (pageSize <= 0)
                pageSize = 10;
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            if (pageIndex < 0)
                pageIndex = 0;
            if (pageIndex == int.MaxValue)
                pageIndex = int.MaxValue - 1;

            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllTopics(forumId,
                userId, keywords, searchPosts, pageSize, pageIndex, out totalRecords);
            var forumTopicCollection = DBMapping(dbCollection);

            return forumTopicCollection;
        }
        
        /// <summary>
        /// Gets active topics
        /// </summary>
        /// <param name="forumId">The forum group identifier</param>
        /// <param name="topicCount">Topic count. 0 if you want to get all topics</param>
        /// <returns>Topics</returns>
        public static ForumTopicCollection GetActiveTopics(int forumId, int topicCount)
        {
            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetActiveTopics(forumId, topicCount);
            var forumTopicCollection = DBMapping(dbCollection);

            return forumTopicCollection;
        }
        
        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="topicType">The topic type</param>
        /// <param name="subject">The subject</param>
        /// <param name="numPosts">The number of posts</param>
        /// <param name="views">The number of views</param>
        /// <param name="lastPostId">The last post identifier</param>
        /// <param name="lastPostUserId">The last post user identifier</param>
        /// <param name="lastPostTime">The last post date and time</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to users</param>
        /// <returns>Topic</returns>
        public static ForumTopic InsertTopic(int forumId, int userId,
            ForumTopicTypeEnum topicType, string subject,
            int numPosts, int views, int lastPostId,
            int lastPostUserId, DateTime? lastPostTime,
            DateTime createdOn, DateTime updatedOn, bool sendNotifications)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            if (subject == null)
                subject = string.Empty;

            subject = subject.Trim();

            if (String.IsNullOrEmpty(subject))
                throw new NopException("Topic subject cannot be empty");

            if (ForumManager.TopicSubjectMaxLength > 0)
            {
                if (subject.Length > ForumManager.TopicSubjectMaxLength)
                    subject = subject.Substring(0, ForumManager.TopicSubjectMaxLength);
            }

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertTopic(forumId, 
                userId, (int)topicType, subject, numPosts, views, lastPostId,
                lastPostUserId, lastPostTime, createdOn, updatedOn);

            var forumTopic = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            if (sendNotifications)
            {
                var forum = forumTopic.Forum;
                var subscriptions = GetAllSubscriptions(0, forum.ForumId, 0, int.MaxValue, 0);

                foreach (var subscription in subscriptions)
                {
                    if (subscription.UserId == userId)
                        continue;

                    MessageManager.SendNewForumTopicMessage(subscription.User, 
                        forumTopic, forum, NopContext.Current.WorkingLanguage.LanguageId);
                }
            }

            return forumTopic;
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="topicType">The topic type</param>
        /// <param name="subject">The subject</param>
        /// <param name="numPosts">The number of posts</param>
        /// <param name="views">The number of views</param>
        /// <param name="lastPostId">The last post identifier</param>
        /// <param name="lastPostUserId">The last post user identifier</param>
        /// <param name="lastPostTime">The last post date and time</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Topic</returns>
        public static ForumTopic UpdateTopic(int forumTopicId, int forumId, 
            int userId, ForumTopicTypeEnum topicType, string subject,
            int numPosts, int views, int lastPostId, int lastPostUserId, 
            DateTime? lastPostTime, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            if (subject == null)
                subject = string.Empty;

            subject = subject.Trim();

            if (String.IsNullOrEmpty(subject))
                throw new NopException("Topic subject cannot be empty");

            if (ForumManager.TopicSubjectMaxLength > 0)
            {
                if (subject.Length > ForumManager.TopicSubjectMaxLength)
                    subject = subject.Substring(0, ForumManager.TopicSubjectMaxLength);
            }

            var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdateTopic(forumTopicId,
                forumId, userId, (int)topicType, subject,
                numPosts, views, lastPostId, lastPostUserId, lastPostTime, 
                createdOn, updatedOn);

            var forumTopic = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forumTopic;
        }

        /// <summary>
        /// Moves the topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="newForumId">New forum identifier</param>
        /// <returns>Moved topic</returns>
        public static ForumTopic MoveTopic(int forumTopicId, int newForumId)
        {
            var forumTopic = GetTopicById(forumTopicId);
            if (forumTopic == null)
                return forumTopic;

            if (ForumManager.IsUserAllowedToMoveTopic(NopContext.Current.User, forumTopic))
            {
                int previousForumId = forumTopic.ForumId;
                var newForum = GetForumById(newForumId);

                if (newForum != null)
                {
                    if (previousForumId != newForumId)
                    {
                        forumTopic = UpdateTopic(forumTopic.ForumTopicId, newForum.ForumId,
                            forumTopic.UserId, forumTopic.TopicType, forumTopic.Subject, forumTopic.NumPosts,
                            forumTopic.Views, forumTopic.LastPostId, forumTopic.LastPostUserId,
                            forumTopic.LastPostTime, forumTopic.CreatedOn, DateTime.Now);

                        //update forum stats
                        UpdateForumStats(previousForumId);
                        UpdateForumStats(newForumId);
                    }
                }
            }
            return forumTopic;
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        /// <param name="forumPostId">The post identifier</param>
        public static void DeletePost(int forumPostId)
        {
            var forumPost = ForumManager.GetPostById(forumPostId);
            int forumTopicId = 0;
            if (forumPost != null)
            {
                forumTopicId = forumPost.TopicId;
            }
             
            //delete topic if it was the first post
            var forumTopic = ForumManager.GetTopicById(forumTopicId);
            if (forumTopic != null)
            {
                ForumPost firstPost = forumTopic.FirstPost;
                if (firstPost != null && firstPost.ForumPostId == forumPostId)
                {
                    ForumManager.DeleteTopic(forumTopic.ForumTopicId);
                }
            }

            DBProviderManager<DBForumProvider>.Provider.DeletePost(forumPostId);
          

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a post
        /// </summary>
        /// <param name="forumPostId">The post identifier</param>
        /// <returns>Post</returns>
        public static ForumPost GetPostById(int forumPostId)
        {
            if (forumPostId == 0)
                return null;

            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetPostById(forumPostId);
            var forumPost = DBMapping(dbItem);

            return forumPost;
        }

        /// <summary>
        /// Gets all posts
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Posts</returns>
        public static ForumPostCollection GetAllPosts(int forumTopicId,
            int userId, string keywords, int pageSize, int pageIndex, out int totalRecords)
        {
            return GetAllPosts(forumTopicId, userId, keywords, true,
                pageSize, pageIndex, out totalRecords);
        }

        /// <summary>
        /// Gets all posts
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="ascSort">Sort order</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Posts</returns>
        public static ForumPostCollection GetAllPosts(int forumTopicId, int userId,
            string keywords, bool ascSort, int pageSize, int pageIndex, out int totalRecords)
        {
            if (pageSize <= 0)
                pageSize = 10;
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            if (pageIndex < 0)
                pageIndex = 0;
            if (pageIndex == int.MaxValue)
                pageIndex = int.MaxValue - 1;

            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllPosts(forumTopicId,
                userId, keywords, ascSort, pageSize, pageIndex, out totalRecords);
            var forumPostCollection = DBMapping(dbCollection);

            return forumPostCollection;
        }

        /// <summary>
        /// Inserts a post
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="text">The text</param>
        /// <param name="ipAddress">The IP address</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to users</param>
        /// <returns>Post</returns>
        public static ForumPost InsertPost(int forumTopicId, int userId,
            string text, string ipAddress, DateTime createdOn, DateTime updatedOn, 
            bool sendNotifications)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            if (text == null)
                text = string.Empty;

            text = text.Trim();

            if (String.IsNullOrEmpty(text))
                throw new NopException("Text cannot be empty");

            if (ForumManager.PostMaxLength > 0)
            {
                if (text.Length > ForumManager.PostMaxLength)
                    text = text.Substring(0, ForumManager.PostMaxLength);
            }

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertPost(forumTopicId,
                userId, text, ipAddress, createdOn, updatedOn);

            var forumPost = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            if (sendNotifications)
            {
                var forumTopic = forumPost.Topic;
                var forum = forumTopic.Forum;
                var subscriptions = GetAllSubscriptions(0, 0, 
                    forumTopic.ForumTopicId, int.MaxValue, 0);
                
                foreach (ForumSubscription subscription in subscriptions)
                {
                    if (subscription.UserId == userId)
                        continue;

                    MessageManager.SendNewForumPostMessage(subscription.User,
                        forumTopic, forum, NopContext.Current.WorkingLanguage.LanguageId);
                }
            }

            return forumPost;
        }

        /// <summary>
        /// Updates the post
        /// </summary>
        /// <param name="forumPostId">The forum post identifier</param>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="text">The text</param>
        /// <param name="ipAddress">The IP address</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Post</returns>
        public static ForumPost UpdatePost(int forumPostId, int forumTopicId, int userId,
            string text, string ipAddress, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            if (text == null)
                text = string.Empty;

            text = text.Trim();

            if (String.IsNullOrEmpty(text))
                throw new NopException("Text cannot be empty");

            if (ForumManager.PostMaxLength > 0)
            {
                if (text.Length > ForumManager.PostMaxLength)
                    text = text.Substring(0, ForumManager.PostMaxLength);
            }
            var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdatePost(forumPostId, 
                forumTopicId, userId, text, ipAddress, createdOn, updatedOn);

            var forumPost = DBMapping(dbItem);

            if (ForumManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(FORUMGROUP_PATTERN_KEY);
                NopCache.RemoveByPattern(FORUM_PATTERN_KEY);
            }

            return forumPost;
        }

        /// <summary>
        /// Deletes a private message
        /// </summary>
        /// <param name="forumPrivateMessageId">The private message identifier</param>
        public static void DeletePrivateMessage(int forumPrivateMessageId)
        {
            DBProviderManager<DBForumProvider>.Provider.DeletePrivateMessage(forumPrivateMessageId);
        }

        /// <summary>
        /// Gets a private message
        /// </summary>
        /// <param name="forumPrivateMessageId">The private message identifier</param>
        /// <returns>Private message</returns>
        public static PrivateMessage GetPrivateMessageById(int forumPrivateMessageId)
        {
            if (forumPrivateMessageId == 0)
                return null;

            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetPrivateMessageById(forumPrivateMessageId);
            var privateMessage = DBMapping(dbItem);

            return privateMessage;
        }

        /// <summary>
        /// Gets private messages
        /// </summary>
        /// <param name="fromUserId">The user identifier who sent the message</param>
        /// <param name="toUserId">The user identifier who should receive the message</param>
        /// <param name="isRead">A value indicating whether loaded messages are read. false - to load not read messages only, 1 to load read messages only, null to load all messages</param>
        /// <param name="isDeletedByAuthor">A value indicating whether loaded messages are deleted by author. false - messages are not deleted by author, null to load all messages</param>
        /// <param name="isDeletedByRecipient">A value indicating whether loaded messages are deleted by recipient. false - messages are not deleted by recipient, null to load all messages</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Private messages</returns>
        public static PrivateMessageCollection GetAllPrivateMessages(int fromUserId,
            int toUserId, bool? isRead, bool? isDeletedByAuthor, bool? isDeletedByRecipient,
            string keywords, int pageSize, int pageIndex, out int totalRecords)
        {
            if (pageSize <= 0)
                pageSize = 10;
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            if (pageIndex < 0)
                pageIndex = 0;
            if (pageIndex == int.MaxValue)
                pageIndex = int.MaxValue - 1;

            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllPrivateMessages(fromUserId,
                toUserId, isRead, isDeletedByAuthor, isDeletedByRecipient, 
                keywords, pageSize, pageIndex, out totalRecords);
            var privateMessageCollection = DBMapping(dbCollection);

            return privateMessageCollection;
        }

        /// <summary>
        /// Inserts a private message
        /// </summary>
        /// <param name="fromUserId">The user identifier who sent the message</param>
        /// <param name="toUserId">The user identifier who should receive the message</param>
        /// <param name="subject">The subject</param>
        /// <param name="text">The text</param>
        /// <param name="isRead">The value indivating whether message is read</param>
        /// <param name="isDeletedByAuthor">The value indivating whether message is deleted by author</param>
        /// <param name="isDeletedByRecipient">The value indivating whether message is deleted by recipient</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>Private message</returns>
        public static PrivateMessage InsertPrivateMessage(int fromUserId,
            int toUserId, string subject, string text, bool isRead,
            bool isDeletedByAuthor, bool isDeletedByRecipient, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            if (subject == null)
                subject = string.Empty;
            subject = subject.Trim();
            if (String.IsNullOrEmpty(subject))
                throw new NopException("Subject cannot be empty");
            if (ForumManager.PMSubjectMaxLength > 0)
            {
                if (subject.Length > ForumManager.PMSubjectMaxLength)
                    subject = subject.Substring(0, ForumManager.PMSubjectMaxLength);
            }

            if (text == null)
                text = string.Empty;
            text = text.Trim();
            if (String.IsNullOrEmpty(text))
                throw new NopException("Text cannot be empty");
            if (ForumManager.PMTextMaxLength > 0)
            {
                if (text.Length > ForumManager.PMTextMaxLength)
                    text = text.Substring(0, ForumManager.PMTextMaxLength);
            }

            Customer customerTo = CustomerManager.GetCustomerById(toUserId);
            if (customerTo == null)
                throw new NopException("Recipient could not be loaded");

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertPrivateMessage(fromUserId,
                toUserId, subject, text, isRead, isDeletedByAuthor, isDeletedByRecipient, createdOn);

            var privateMessage = DBMapping(dbItem);
            
            //notofications
            customerTo.NotifiedAboutNewPrivateMessages = false;

            return privateMessage;
        }

        /// <summary>
        /// Updates the private message
        /// </summary>
        /// <param name="privateMessageId">The private message identifier</param>
        /// <param name="fromUserId">The user identifier who sent the message</param>
        /// <param name="toUserId">The user identifier who should receive the message</param>
        /// <param name="subject">The subject</param>
        /// <param name="text">The text</param>
        /// <param name="isRead">The value indivating whether message is read</param>
        /// <param name="isDeletedByAuthor">The value indivating whether message is deleted by author</param>
        /// <param name="isDeletedByRecipient">The value indivating whether message is deleted by recipient</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>Private message</returns>
        public static PrivateMessage UpdatePrivateMessage(int privateMessageId,
            int fromUserId, int toUserId, string subject, string text, bool isRead,
            bool isDeletedByAuthor, bool isDeletedByRecipient, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            if (subject == null)
                subject = string.Empty;
            subject = subject.Trim();
            if (String.IsNullOrEmpty(subject))
                throw new NopException("Subject cannot be empty");
            if (ForumManager.PMSubjectMaxLength > 0)
            {
                if (subject.Length > ForumManager.PMSubjectMaxLength)
                    subject = subject.Substring(0, ForumManager.PMSubjectMaxLength);
            }

            if (text == null)
                text = string.Empty;
            text = text.Trim();
            if (String.IsNullOrEmpty(text))
                throw new NopException("Text cannot be empty");
            if (ForumManager.PMTextMaxLength > 0)
            {
                if (text.Length > ForumManager.PMTextMaxLength)
                    text = text.Substring(0, ForumManager.PMTextMaxLength);
            }

            if (isDeletedByAuthor && isDeletedByRecipient)
            {
                DeletePrivateMessage(privateMessageId);
                return null;
            }
            else
            {
                var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdatePrivateMessage(privateMessageId,
                    fromUserId, toUserId, subject, text, isRead,
                    isDeletedByAuthor, isDeletedByRecipient, createdOn);
                var privateMessage = DBMapping(dbItem);
                return privateMessage;
            }
        }

        /// <summary>
        /// Deletes a forum subscription
        /// </summary>
        /// <param name="forumSubscriptionId">The forum subscription identifier</param>
        public static void DeleteSubscription(int forumSubscriptionId)
        {
            DBProviderManager<DBForumProvider>.Provider.DeleteSubscription(forumSubscriptionId);
        }

        /// <summary>
        /// Gets a forum subscription
        /// </summary>
        /// <param name="forumSubscriptionId">The forum subscription identifier</param>
        /// <returns>Forum subscription</returns>
        public static ForumSubscription GetSubscriptionById(int forumSubscriptionId)
        {
            if (forumSubscriptionId == 0)
                return null;

            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetSubscriptionById(forumSubscriptionId);
            var forumSubscription = DBMapping(dbItem);
            return forumSubscription;
        }

        /// <summary>
        /// Gets a forum subscription
        /// </summary>
        /// <param name="subscriptionGuid">The forum subscription identifier</param>
        /// <returns>Forum subscription</returns>
        public static ForumSubscription GetSubscriptionByGuid(int subscriptionGuid)
        {
            var dbItem = DBProviderManager<DBForumProvider>.Provider.GetSubscriptionByGuid(subscriptionGuid);
            var forumSubscription = DBMapping(dbItem);

            return forumSubscription;
        }

        /// <summary>
        /// Gets forum subscriptions
        /// </summary>
        /// <param name="userId">The user identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="topicId">The topic identifier</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Forum subscriptions</returns>
        public static ForumSubscriptionCollection GetAllSubscriptions(int userId, 
            int forumId, int topicId, int pageSize, int pageIndex)
        {
            int totalRecords = 0;
            return GetAllSubscriptions(userId, forumId, topicId, pageSize, 
                pageIndex, out totalRecords);
        }

        /// <summary>
        /// Gets forum subscriptions
        /// </summary>
        /// <param name="userId">The user identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="topicId">The topic identifier</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Forum subscriptions</returns>
        public static ForumSubscriptionCollection GetAllSubscriptions(int userId, int forumId,
            int topicId, int pageSize, int pageIndex, out int totalRecords)
        {
            if (pageSize <= 0)
                pageSize = 10;
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            if (pageIndex < 0)
                pageIndex = 0;
            if (pageIndex == int.MaxValue)
                pageIndex = int.MaxValue - 1;

            var dbCollection = DBProviderManager<DBForumProvider>.Provider.GetAllSubscriptions(userId,
                forumId, topicId, pageSize, pageIndex, out totalRecords);
            var forumSubscriptionCollection = DBMapping(dbCollection);

            return forumSubscriptionCollection;
        }

        /// <summary>
        /// Inserts a forum subscription
        /// </summary>
        /// <param name="subscriptionGuid">The forum subscription identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="topicId">The topic identifier</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>Forum subscription</returns>
        public static ForumSubscription InsertSubscription(Guid subscriptionGuid, int userId,
            int forumId, int topicId, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.InsertSubscription(subscriptionGuid, 
                userId, forumId, topicId, createdOn);
            
            var forumSubscription = DBMapping(dbItem);

            return forumSubscription;
        }

        /// <summary>
        /// Updates the forum subscription
        /// </summary>
        /// <param name="subscriptionId">The forum subscription identifier</param>
        /// <param name="subscriptionGuid">The forum subscription identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="topicId">The topic identifier</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <returns>Forum subscription</returns>
        public static ForumSubscription UpdateSubscription(int subscriptionId, 
            Guid subscriptionGuid, int userId, int forumId, int topicId, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            var dbItem = DBProviderManager<DBForumProvider>.Provider.UpdateSubscription(subscriptionId,
                subscriptionGuid, userId, forumId, topicId, createdOn);

            var forumSubscription = DBMapping(dbItem);

            return forumSubscription;
        }

        /// <summary>
        /// Check whether user is allowed to create new topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="forum">Forum</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToCreateTopic(Customer customer, Forum forum)
        {
            if (forum == null)
                return false;

            if (customer == null)
                return false;

            if(customer.IsGuest && !AllowGuestsToCreateTopics)
                return false;

            if (customer.IsForumModerator)
                return true;

            return true;
        }

        /// <summary>
        /// Check whether user is allowed to edit topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToEditTopic(Customer customer, ForumTopic topic)
        {
            if (topic == null)
                return false;

            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;

            if (ForumManager.AllowCustomersToEditPosts)
            {
                bool ownTopic = customer.CustomerId == topic.UserId;
                return ownTopic;
            }

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to move topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToMoveTopic(Customer customer, ForumTopic topic)
        {
            if (topic == null)
                return false;

            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to delete topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToDeleteTopic(Customer customer, ForumTopic topic)
        {
            if (topic == null)
                return false;

            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;
            
            if (ForumManager.AllowCustomersToDeletePosts)
            {
                bool ownTopic = customer.CustomerId == topic.UserId;
                return ownTopic;
            }

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to create new post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToCreatePost(Customer customer, ForumTopic topic)
        {
            if (topic == null)
                return false;

            if (customer == null)
                return false;

            if(customer.IsGuest && !AllowGuestsToCreatePosts)
                return false;

            if (customer.IsForumModerator)
                return true;

            return true;
        }

        /// <summary>
        /// Check whether user is allowed to edit post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToEditPost(Customer customer, ForumPost post)
        {
            if (post == null)
                return false;

            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;
            
            if (ForumManager.AllowCustomersToEditPosts)
            {
                bool ownPost = customer.CustomerId == post.UserId;
                return ownPost;
            }

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to delete post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToDeletePost(Customer customer, ForumPost post)
        {
            if (post == null)
                return false;

            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;

            if (ForumManager.AllowCustomersToDeletePosts)
            {
                bool ownPost = customer.CustomerId == post.UserId;
                return ownPost;
            }

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to set topic priority
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToSetTopicPriority(Customer customer)
        {
            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            if (customer.IsForumModerator)
                return true;

            return false;
        }

        /// <summary>
        /// Check whether user is allowed to watch topics
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToSubscribe(int customerId)
        {
            var customer = CustomerManager.GetCustomerById(customerId);
            return IsUserAllowedToSubscribe(customer);
        }

        /// <summary>
        /// Check whether user is allowed to watch topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public static bool IsUserAllowedToSubscribe(Customer customer)
        {
            if (customer == null)
                return false;

            if (customer.IsGuest)
                return false;

            return true;
        }

        /// <summary>
        /// Formats the posts text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Formatted text</returns>
        public static string FormatPostText(string text)
        {
            if (String.IsNullOrEmpty(text))
                return string.Empty;

            switch (ForumManager.ForumEditor)
            {
                case EditorTypeEnum.SimpleTextBox:
                    {
                        text = HtmlHelper.FormatText(text, false, true, false, false, false, false);
                    }
                    break;
                case EditorTypeEnum.BBCodeEditor:
                    {
                        text = HtmlHelper.FormatText(text, false, true, false, true, false, false);
                    }
                    break;
                case EditorTypeEnum.HtmlEditor:
                    {
                        text = HtmlHelper.FormatText(text, false, false, true, false, false, false);
                    }
                    break;
                default:
                    break;
            }

            return text;
        }

        /// <summary>
        /// Formats the signature text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Formatted text</returns>
        public static string FormatSignatureText(string text)
        {
            if (String.IsNullOrEmpty(text))
                return string.Empty;

            text = HtmlHelper.FormatText(text, false, true, false, false, false, false);
            return text;
        }

        /// <summary>
        /// Formats the private message text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Formatted text</returns>
        public static string FormatPrivateMessageText(string text)
        {
            if (String.IsNullOrEmpty(text))
                return string.Empty;

            text = HtmlHelper.FormatText(text, false, true, false, true, false, false);

            return text;
        }

        /// <summary>
        /// Strips topic subject
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <returns>Formatted subject</returns>
        public static string StripTopicSubject(string subject)
        {
            if (String.IsNullOrEmpty(subject))
                return subject;
            int StrippedTopicMaxLength = SettingManager.GetSettingValueInteger("Forums.StrippedTopicMaxLength", 45);
            if (StrippedTopicMaxLength > 0)
            {
                if (subject.Length > StrippedTopicMaxLength)
                {
                    int index = subject.IndexOf(" ", StrippedTopicMaxLength);
                    if (index > 0)
                    {
                        subject = subject.Substring(0, index);
                        subject += "...";
                    }
                }
            }

            return subject;
        }

        /// <summary>
        /// Calculates topic page index by post identifier
        /// </summary>
        /// <param name="forumTopicId">Topic identifier</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="postId">Post identifier</param>
        /// <returns>Page index</returns>
        public static int CalculateTopicPageIndex(int forumTopicId, int pageSize, int postId)
        {
            int pageIndex = 0;
            int totalRecords = 0;
            var forumPosts = ForumManager.GetAllPosts(forumTopicId, 0, 
                string.Empty, true, int.MaxValue, 0, out totalRecords);

            for (int i = 0; i < totalRecords; i++)
            {
                if (forumPosts[i].ForumPostId == postId)
                {
                    if (pageSize > 0)
                    {
                        pageIndex = i/pageSize;
                    }
                }
            }

            return pageIndex;
        }

        #endregion
        
        #region Property

        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public static bool CacheEnabled
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Cache.ForumManager.CacheEnabled");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether forums are enabled
        /// </summary>
        public static bool ForumsEnabled
        {
            get
            {
                bool forumsEnabled = SettingManager.GetSettingValueBoolean("Forums.ForumsEnabled");
                return forumsEnabled;
            }
            set
            {
                SettingManager.SetParam("Forums.ForumsEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to edit posts that they created.
        /// </summary>
        public static bool AllowCustomersToEditPosts
        {
            get
            {
                bool allowCustomersToEditPosts = SettingManager.GetSettingValueBoolean("Forums.CustomersAllowedToEditPosts");
                return allowCustomersToEditPosts;
            }
            set
            {
                SettingManager.SetParam("Forums.CustomersAllowedToEditPosts", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the guests are allowed to create posts.
        /// </summary>
        public static bool AllowGuestsToCreatePosts
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Forums.GuestsAllowedToCreatePosts");
            }
            set
            {
                SettingManager.SetParam("Forums.GuestsAllowedToCreatePosts", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the guests are allowed to create topics.
        /// </summary>
        public static bool AllowGuestsToCreateTopics
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Forums.GuestsAllowedToCreateTopics");
            }
            set
            {
                SettingManager.SetParam("Forums.GuestsAllowedToCreateTopics", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to delete posts that they created.
        /// </summary>
        public static bool AllowCustomersToDeletePosts
        {
            get
            {
                bool allowCustomersToDeletePosts = SettingManager.GetSettingValueBoolean("Forums.CustomersAllowedToDeletePosts");
                return allowCustomersToDeletePosts;
            }
            set
            {
                SettingManager.SetParam("Forums.CustomersAllowedToDeletePosts", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets maximum length of topic subject
        /// </summary>
        public static int TopicSubjectMaxLength
        {
            get
            {
                int topicSubjectMaxLength = SettingManager.GetSettingValueInteger("Forums.TopicSubjectMaxLength");
                return topicSubjectMaxLength;
            }
            set
            {
                SettingManager.SetParam("Forums.TopicSubjectMaxLength", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets maximum length of post
        /// </summary>
        public static int PostMaxLength
        {
            get
            {
                int postMaxLength = SettingManager.GetSettingValueInteger("Forums.PostMaxLength");
                return postMaxLength;
            }
            set
            {
                SettingManager.SetParam("Forums.PostMaxLength", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the page size for topics in forums
        /// </summary>
        public static int TopicsPageSize
        {
            get
            {
                int topicsPageSize = SettingManager.GetSettingValueInteger("Forums.TopicsPageSize");
                return topicsPageSize;
            }
            set
            {
                SettingManager.SetParam("Forums.TopicsPageSize", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the page size for posts in topics
        /// </summary>
        public static int PostsPageSize
        {
            get
            {
                int postsPageSize = SettingManager.GetSettingValueInteger("Forums.PostsPageSize");
                return postsPageSize;
            }
            set
            {
                SettingManager.SetParam("Forums.PostsPageSize", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the page size for search result
        /// </summary>
        public static int SearchResultsPageSize
        {
            get
            {
                int searchResultsPageSize = SettingManager.GetSettingValueInteger("Forums.SearchResultsPageSize");
                return searchResultsPageSize;
            }
            set
            {
                SettingManager.SetParam("Forums.SearchResultsPageSize", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the page size for latest user post
        /// </summary>
        public static int LatestUserPostsPageSize
        {
            get
            {
                int latestUserPostsPageSize = SettingManager.GetSettingValueInteger("Forums.LatestUserPostsPageSize");
                return latestUserPostsPageSize;
            }
            set
            {
                SettingManager.SetParam("Forums.LatestUserPostsPageSize", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show customers forum post count
        /// </summary>
        public static bool ShowCustomersPostCount
        {
            get
            {
                bool showCustomersPostCount = SettingManager.GetSettingValueBoolean("Forums.ShowCustomersPostCount");
                return showCustomersPostCount;
            }
            set
            {
                SettingManager.SetParam("Forums.ShowCustomersPostCount", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a forum editor type
        /// </summary>
        public static EditorTypeEnum ForumEditor
        {
            get
            {
                int forumEditorTypeId = SettingManager.GetSettingValueInteger("Forums.EditorType");
                return (EditorTypeEnum)Enum.ToObject(typeof(EditorTypeEnum), forumEditorTypeId);
            }
            set
            {
                SettingManager.SetParam("Forums.EditorType", ((int)value).ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to specify signature.
        /// </summary>
        public static bool SignaturesEnabled
        {
            get
            {
                bool signaturesEnabled = SettingManager.GetSettingValueBoolean("Forums.SignatureEnabled");
                return signaturesEnabled;
            }
            set
            {
                SettingManager.SetParam("Forums.SignatureEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether private messages are allowed
        /// </summary>
        public static bool AllowPrivateMessages
        {
            get
            {
                bool forumsEnabled = SettingManager.GetSettingValueBoolean("Messaging.AllowPM");
                return forumsEnabled;
            }
            set
            {
                SettingManager.SetParam("Messaging.AllowPM", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets maximum length of pm subject
        /// </summary>
        public static int PMSubjectMaxLength
        {
            get
            {
                int pmSubjectMaxLength = SettingManager.GetSettingValueInteger("Messaging.PMSubjectMaxLength");
                return pmSubjectMaxLength;
            }
            set
            {
                SettingManager.SetParam("Messaging.PMSubjectMaxLength", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets maximum length of pm message
        /// </summary>
        public static int PMTextMaxLength
        {
            get
            {
                int pmTextMaxLength = SettingManager.GetSettingValueInteger("Messaging.PMTextMaxLength");
                return pmTextMaxLength;
            }
            set
            {
                SettingManager.SetParam("Messaging.PMTextMaxLength", value.ToString());
            }
        }

        #endregion
    }
}
