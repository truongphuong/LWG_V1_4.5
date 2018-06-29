using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using LWG.Core.Models.Mapping;

namespace LWG.Core.Models
{
    public partial class LudwigContext : DbContext, IDbContext
    {
        static LudwigContext()
        {
            Database.SetInitializer<LudwigContext>(null);
        }

        public LudwigContext()
            : base("Name=LudwigContext")
        {
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public bool IsAttached(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            ObjectStateEntry entry;
            try
            {
                entry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
                return (entry.State != EntityState.Detached);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
            return false;

        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var result = this.Database.ExecuteSqlCommand(sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        public DbSet<lwg_Audio> lwg_Audio { get; set; }
        public DbSet<lwg_Catalog> lwg_Catalog { get; set; }
        public DbSet<lwg_CatalogGenre> lwg_CatalogGenre { get; set; }
        public DbSet<lwg_CatalogInstrumentSearch> lwg_CatalogInstrumentSearch { get; set; }
        public DbSet<lwg_CatalogNameSearch> lwg_CatalogNameSearch { get; set; }
        public DbSet<lwg_CatalogPublisher> lwg_CatalogPublisher { get; set; }
        public DbSet<lwg_CatalogTitle> lwg_CatalogTitle { get; set; }
        public DbSet<lwg_CatalogTitleSearch> lwg_CatalogTitleSearch { get; set; }
        public DbSet<lwg_Dealer> lwg_Dealer { get; set; }
        public DbSet<lwg_Genre> lwg_Genre { get; set; }
        public DbSet<lwg_HtmlContent> lwg_HtmlContent { get; set; }
        public DbSet<lwg_InstrTitle> lwg_InstrTitle { get; set; }
        public DbSet<lwg_Instrumental> lwg_Instrumental { get; set; }
        public DbSet<lwg_LicenseForm> lwg_LicenseForm { get; set; }
        public DbSet<lwg_Period> lwg_Period { get; set; }
        public DbSet<lwg_PeriodMapping> lwg_PeriodMapping { get; set; }
        public DbSet<lwg_Person> lwg_Person { get; set; }
        public DbSet<lwg_PersonInRole> lwg_PersonInRole { get; set; }
        public DbSet<lwg_Publisher> lwg_Publisher { get; set; }
        public DbSet<lwg_ReprintSource> lwg_ReprintSource { get; set; }
        public DbSet<lwg_ReprintSourceMapping> lwg_ReprintSourceMapping { get; set; }
        public DbSet<lwg_Role> lwg_Role { get; set; }
        public DbSet<lwg_Series> lwg_Series { get; set; }
        public DbSet<lwg_SeriesMapping> lwg_SeriesMapping { get; set; }
        public DbSet<lwg_ShippingConvertionConfig> lwg_ShippingConvertionConfig { get; set; }
        public DbSet<lwg_TitleType> lwg_TitleType { get; set; }
        public DbSet<lwg_Video> lwg_Video { get; set; }
        public DbSet<Nop_ACL> Nop_ACL { get; set; }
        public DbSet<Nop_ActivityLog> Nop_ActivityLog { get; set; }
        public DbSet<Nop_ActivityLogType> Nop_ActivityLogType { get; set; }
        public DbSet<Nop_Address> Nop_Address { get; set; }
        public DbSet<Nop_Affiliate> Nop_Affiliate { get; set; }
        public DbSet<Nop_BannedIpAddress> Nop_BannedIpAddress { get; set; }
        public DbSet<Nop_BannedIpNetwork> Nop_BannedIpNetwork { get; set; }
        public DbSet<Nop_BlogComment> Nop_BlogComment { get; set; }
        public DbSet<Nop_BlogPost> Nop_BlogPost { get; set; }
        public DbSet<Nop_Campaign> Nop_Campaign { get; set; }
        public DbSet<Nop_Category> Nop_Category { get; set; }
        public DbSet<Nop_Category_Discount_Mapping> Nop_Category_Discount_Mapping { get; set; }
        public DbSet<Nop_CategoryLocalized> Nop_CategoryLocalized { get; set; }
        public DbSet<Nop_CategoryTemplate> Nop_CategoryTemplate { get; set; }
        public DbSet<Nop_CheckoutAttribute> Nop_CheckoutAttribute { get; set; }
        public DbSet<Nop_CheckoutAttributeLocalized> Nop_CheckoutAttributeLocalized { get; set; }
        public DbSet<Nop_CheckoutAttributeValue> Nop_CheckoutAttributeValue { get; set; }
        public DbSet<Nop_CheckoutAttributeValueLocalized> Nop_CheckoutAttributeValueLocalized { get; set; }
        public DbSet<Nop_Country> Nop_Country { get; set; }
        public DbSet<Nop_CreditCardType> Nop_CreditCardType { get; set; }
        public DbSet<Nop_Currency> Nop_Currency { get; set; }
        public DbSet<Nop_Customer> Nop_Customer { get; set; }
        public DbSet<Nop_CustomerAction> Nop_CustomerAction { get; set; }
        public DbSet<Nop_CustomerAttribute> Nop_CustomerAttribute { get; set; }
        public DbSet<Nop_CustomerRole> Nop_CustomerRole { get; set; }
        public DbSet<Nop_CustomerRole_Discount_Mapping> Nop_CustomerRole_Discount_Mapping { get; set; }
        public DbSet<Nop_CustomerRole_ProductPrice> Nop_CustomerRole_ProductPrice { get; set; }
        public DbSet<Nop_CustomerSession> Nop_CustomerSession { get; set; }
        public DbSet<Nop_Discount> Nop_Discount { get; set; }
        public DbSet<Nop_DiscountLimitation> Nop_DiscountLimitation { get; set; }
        public DbSet<Nop_DiscountRequirement> Nop_DiscountRequirement { get; set; }
        public DbSet<Nop_DiscountType> Nop_DiscountType { get; set; }
        public DbSet<Nop_DiscountUsageHistory> Nop_DiscountUsageHistory { get; set; }
        public DbSet<Nop_Download> Nop_Download { get; set; }
        public DbSet<Nop_EmailDirectory> Nop_EmailDirectory { get; set; }
        public DbSet<Nop_Forums_Forum> Nop_Forums_Forum { get; set; }
        public DbSet<Nop_Forums_Group> Nop_Forums_Group { get; set; }
        public DbSet<Nop_Forums_Post> Nop_Forums_Post { get; set; }
        public DbSet<Nop_Forums_PrivateMessage> Nop_Forums_PrivateMessage { get; set; }
        public DbSet<Nop_Forums_Subscription> Nop_Forums_Subscription { get; set; }
        public DbSet<Nop_Forums_Topic> Nop_Forums_Topic { get; set; }
        public DbSet<Nop_GiftCard> Nop_GiftCard { get; set; }
        public DbSet<Nop_GiftCardUsageHistory> Nop_GiftCardUsageHistory { get; set; }
        public DbSet<Nop_Language> Nop_Language { get; set; }
        public DbSet<Nop_LocaleStringResource> Nop_LocaleStringResource { get; set; }
        public DbSet<Nop_Log> Nop_Log { get; set; }
        public DbSet<Nop_LogType> Nop_LogType { get; set; }
        public DbSet<Nop_LowStockActivity> Nop_LowStockActivity { get; set; }
        public DbSet<Nop_Manufacturer> Nop_Manufacturer { get; set; }
        public DbSet<Nop_ManufacturerLocalized> Nop_ManufacturerLocalized { get; set; }
        public DbSet<Nop_ManufacturerTemplate> Nop_ManufacturerTemplate { get; set; }
        public DbSet<Nop_MeasureDimension> Nop_MeasureDimension { get; set; }
        public DbSet<Nop_MeasureWeight> Nop_MeasureWeight { get; set; }
        public DbSet<Nop_MessageTemplate> Nop_MessageTemplate { get; set; }
        public DbSet<Nop_MessageTemplateLocalized> Nop_MessageTemplateLocalized { get; set; }
        public DbSet<Nop_News> Nop_News { get; set; }
        public DbSet<Nop_NewsComment> Nop_NewsComment { get; set; }
        public DbSet<Nop_NewsLetterSubscription> Nop_NewsLetterSubscription { get; set; }
        public DbSet<Nop_Order> Nop_Order { get; set; }
        public DbSet<Nop_OrderNote> Nop_OrderNote { get; set; }
        public DbSet<Nop_OrderProductVariant> Nop_OrderProductVariant { get; set; }
        public DbSet<Nop_OrderStatus> Nop_OrderStatus { get; set; }
        public DbSet<Nop_PaymentMethod> Nop_PaymentMethod { get; set; }
        public DbSet<Nop_PaymentStatus> Nop_PaymentStatus { get; set; }
        public DbSet<Nop_Picture> Nop_Picture { get; set; }
        public DbSet<Nop_Poll> Nop_Poll { get; set; }
        public DbSet<Nop_PollAnswer> Nop_PollAnswer { get; set; }
        public DbSet<Nop_PollVotingRecord> Nop_PollVotingRecord { get; set; }
        public DbSet<Nop_Pricelist> Nop_Pricelist { get; set; }
        public DbSet<Nop_Product> Nop_Product { get; set; }
        public DbSet<Nop_Product_Category_Mapping> Nop_Product_Category_Mapping { get; set; }
        public DbSet<Nop_Product_Manufacturer_Mapping> Nop_Product_Manufacturer_Mapping { get; set; }
        public DbSet<Nop_Product_SpecificationAttribute_Mapping> Nop_Product_SpecificationAttribute_Mapping { get; set; }
        public DbSet<Nop_ProductAttribute> Nop_ProductAttribute { get; set; }
        public DbSet<Nop_ProductAttributeLocalized> Nop_ProductAttributeLocalized { get; set; }
        public DbSet<Nop_ProductLocalized> Nop_ProductLocalized { get; set; }
        public DbSet<Nop_ProductPicture> Nop_ProductPicture { get; set; }
        public DbSet<Nop_ProductRating> Nop_ProductRating { get; set; }
        public DbSet<Nop_ProductReview> Nop_ProductReview { get; set; }
        public DbSet<Nop_ProductReviewHelpfulness> Nop_ProductReviewHelpfulness { get; set; }
        public DbSet<Nop_ProductTag> Nop_ProductTag { get; set; }
        public DbSet<Nop_ProductTemplate> Nop_ProductTemplate { get; set; }
        public DbSet<Nop_ProductType> Nop_ProductType { get; set; }
        public DbSet<Nop_ProductVariant> Nop_ProductVariant { get; set; }
        public DbSet<Nop_ProductVariant_Pricelist_Mapping> Nop_ProductVariant_Pricelist_Mapping { get; set; }
        public DbSet<Nop_ProductVariant_ProductAttribute_Mapping> Nop_ProductVariant_ProductAttribute_Mapping { get; set; }
        public DbSet<Nop_ProductVariantAttributeCombination> Nop_ProductVariantAttributeCombination { get; set; }
        public DbSet<Nop_ProductVariantAttributeValue> Nop_ProductVariantAttributeValue { get; set; }
        public DbSet<Nop_ProductVariantAttributeValueLocalized> Nop_ProductVariantAttributeValueLocalized { get; set; }
        public DbSet<Nop_ProductVariantLocalized> Nop_ProductVariantLocalized { get; set; }
        public DbSet<Nop_QueuedEmail> Nop_QueuedEmail { get; set; }
        public DbSet<Nop_RecurringPayment> Nop_RecurringPayment { get; set; }
        public DbSet<Nop_RecurringPaymentHistory> Nop_RecurringPaymentHistory { get; set; }
        public DbSet<Nop_RelatedProduct> Nop_RelatedProduct { get; set; }
        public DbSet<Nop_RewardPointsHistory> Nop_RewardPointsHistory { get; set; }
        public DbSet<Nop_SearchLog> Nop_SearchLog { get; set; }
        public DbSet<Nop_Setting> Nop_Setting { get; set; }
        public DbSet<Nop_ShippingByTotal> Nop_ShippingByTotal { get; set; }
        public DbSet<Nop_ShippingByWeight> Nop_ShippingByWeight { get; set; }
        public DbSet<Nop_ShippingByWeightAndCountry> Nop_ShippingByWeightAndCountry { get; set; }
        public DbSet<Nop_ShippingMethod> Nop_ShippingMethod { get; set; }
        public DbSet<Nop_ShippingRateComputationMethod> Nop_ShippingRateComputationMethod { get; set; }
        public DbSet<Nop_ShippingStatus> Nop_ShippingStatus { get; set; }
        public DbSet<Nop_ShoppingCartItem> Nop_ShoppingCartItem { get; set; }
        public DbSet<Nop_ShoppingCartType> Nop_ShoppingCartType { get; set; }
        public DbSet<Nop_SpecificationAttribute> Nop_SpecificationAttribute { get; set; }
        public DbSet<Nop_SpecificationAttributeLocalized> Nop_SpecificationAttributeLocalized { get; set; }
        public DbSet<Nop_SpecificationAttributeOption> Nop_SpecificationAttributeOption { get; set; }
        public DbSet<Nop_SpecificationAttributeOptionLocalized> Nop_SpecificationAttributeOptionLocalized { get; set; }
        public DbSet<Nop_StateProvince> Nop_StateProvince { get; set; }
        public DbSet<Nop_TaxCategory> Nop_TaxCategory { get; set; }
        public DbSet<Nop_TaxProvider> Nop_TaxProvider { get; set; }
        public DbSet<Nop_TaxRate> Nop_TaxRate { get; set; }
        public DbSet<Nop_TierPrice> Nop_TierPrice { get; set; }
        public DbSet<Nop_Topic> Nop_Topic { get; set; }
        public DbSet<Nop_TopicLocalized> Nop_TopicLocalized { get; set; }
        public DbSet<Nop_Warehouse> Nop_Warehouse { get; set; }       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new lwg_AudioMap());
            modelBuilder.Configurations.Add(new lwg_CatalogMap());
            modelBuilder.Configurations.Add(new lwg_CatalogGenreMap());
            modelBuilder.Configurations.Add(new lwg_CatalogInstrumentSearchMap());
            modelBuilder.Configurations.Add(new lwg_CatalogNameSearchMap());
            modelBuilder.Configurations.Add(new lwg_CatalogPublisherMap());
            modelBuilder.Configurations.Add(new lwg_CatalogTitleMap());
            modelBuilder.Configurations.Add(new lwg_CatalogTitleSearchMap());
            modelBuilder.Configurations.Add(new lwg_DealerMap());
            modelBuilder.Configurations.Add(new lwg_GenreMap());
            modelBuilder.Configurations.Add(new lwg_HtmlContentMap());
            modelBuilder.Configurations.Add(new lwg_InstrTitleMap());
            modelBuilder.Configurations.Add(new lwg_InstrumentalMap());
            modelBuilder.Configurations.Add(new lwg_LicenseFormMap());
            modelBuilder.Configurations.Add(new lwg_PeriodMap());
            modelBuilder.Configurations.Add(new lwg_PeriodMappingMap());
            modelBuilder.Configurations.Add(new lwg_PersonMap());
            modelBuilder.Configurations.Add(new lwg_PersonInRoleMap());
            modelBuilder.Configurations.Add(new lwg_PublisherMap());
            modelBuilder.Configurations.Add(new lwg_ReprintSourceMap());
            modelBuilder.Configurations.Add(new lwg_ReprintSourceMappingMap());
            modelBuilder.Configurations.Add(new lwg_RoleMap());
            modelBuilder.Configurations.Add(new lwg_SeriesMap());
            modelBuilder.Configurations.Add(new lwg_SeriesMappingMap());
            modelBuilder.Configurations.Add(new lwg_ShippingConvertionConfigMap());
            modelBuilder.Configurations.Add(new lwg_TitleTypeMap());
            modelBuilder.Configurations.Add(new lwg_VideoMap());
            modelBuilder.Configurations.Add(new Nop_ACLMap());
            modelBuilder.Configurations.Add(new Nop_ActivityLogMap());
            modelBuilder.Configurations.Add(new Nop_ActivityLogTypeMap());
            modelBuilder.Configurations.Add(new Nop_AddressMap());
            modelBuilder.Configurations.Add(new Nop_AffiliateMap());
            modelBuilder.Configurations.Add(new Nop_BannedIpAddressMap());
            modelBuilder.Configurations.Add(new Nop_BannedIpNetworkMap());
            modelBuilder.Configurations.Add(new Nop_BlogCommentMap());
            modelBuilder.Configurations.Add(new Nop_BlogPostMap());
            modelBuilder.Configurations.Add(new Nop_CampaignMap());
            modelBuilder.Configurations.Add(new Nop_CategoryMap());
            modelBuilder.Configurations.Add(new Nop_Category_Discount_MappingMap());
            modelBuilder.Configurations.Add(new Nop_CategoryLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_CategoryTemplateMap());
            modelBuilder.Configurations.Add(new Nop_CheckoutAttributeMap());
            modelBuilder.Configurations.Add(new Nop_CheckoutAttributeLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_CheckoutAttributeValueMap());
            modelBuilder.Configurations.Add(new Nop_CheckoutAttributeValueLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_CountryMap());
            modelBuilder.Configurations.Add(new Nop_CreditCardTypeMap());
            modelBuilder.Configurations.Add(new Nop_CurrencyMap());
            modelBuilder.Configurations.Add(new Nop_CustomerMap());
            modelBuilder.Configurations.Add(new Nop_CustomerActionMap());
            modelBuilder.Configurations.Add(new Nop_CustomerAttributeMap());
            modelBuilder.Configurations.Add(new Nop_CustomerRoleMap());
            modelBuilder.Configurations.Add(new Nop_CustomerRole_Discount_MappingMap());
            modelBuilder.Configurations.Add(new Nop_CustomerRole_ProductPriceMap());
            modelBuilder.Configurations.Add(new Nop_CustomerSessionMap());
            modelBuilder.Configurations.Add(new Nop_DiscountMap());
            modelBuilder.Configurations.Add(new Nop_DiscountLimitationMap());
            modelBuilder.Configurations.Add(new Nop_DiscountRequirementMap());
            modelBuilder.Configurations.Add(new Nop_DiscountTypeMap());
            modelBuilder.Configurations.Add(new Nop_DiscountUsageHistoryMap());
            modelBuilder.Configurations.Add(new Nop_DownloadMap());
            modelBuilder.Configurations.Add(new Nop_EmailDirectoryMap());
            modelBuilder.Configurations.Add(new Nop_Forums_ForumMap());
            modelBuilder.Configurations.Add(new Nop_Forums_GroupMap());
            modelBuilder.Configurations.Add(new Nop_Forums_PostMap());
            modelBuilder.Configurations.Add(new Nop_Forums_PrivateMessageMap());
            modelBuilder.Configurations.Add(new Nop_Forums_SubscriptionMap());
            modelBuilder.Configurations.Add(new Nop_Forums_TopicMap());
            modelBuilder.Configurations.Add(new Nop_GiftCardMap());
            modelBuilder.Configurations.Add(new Nop_GiftCardUsageHistoryMap());
            modelBuilder.Configurations.Add(new Nop_LanguageMap());
            modelBuilder.Configurations.Add(new Nop_LocaleStringResourceMap());
            modelBuilder.Configurations.Add(new Nop_LogMap());
            modelBuilder.Configurations.Add(new Nop_LogTypeMap());
            modelBuilder.Configurations.Add(new Nop_LowStockActivityMap());
            modelBuilder.Configurations.Add(new Nop_ManufacturerMap());
            modelBuilder.Configurations.Add(new Nop_ManufacturerLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_ManufacturerTemplateMap());
            modelBuilder.Configurations.Add(new Nop_MeasureDimensionMap());
            modelBuilder.Configurations.Add(new Nop_MeasureWeightMap());
            modelBuilder.Configurations.Add(new Nop_MessageTemplateMap());
            modelBuilder.Configurations.Add(new Nop_MessageTemplateLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_NewsMap());
            modelBuilder.Configurations.Add(new Nop_NewsCommentMap());
            modelBuilder.Configurations.Add(new Nop_NewsLetterSubscriptionMap());
            modelBuilder.Configurations.Add(new Nop_OrderMap());
            modelBuilder.Configurations.Add(new Nop_OrderNoteMap());
            modelBuilder.Configurations.Add(new Nop_OrderProductVariantMap());
            modelBuilder.Configurations.Add(new Nop_OrderStatusMap());
            modelBuilder.Configurations.Add(new Nop_PaymentMethodMap());
            modelBuilder.Configurations.Add(new Nop_PaymentStatusMap());
            modelBuilder.Configurations.Add(new Nop_PictureMap());
            modelBuilder.Configurations.Add(new Nop_PollMap());
            modelBuilder.Configurations.Add(new Nop_PollAnswerMap());
            modelBuilder.Configurations.Add(new Nop_PollVotingRecordMap());
            modelBuilder.Configurations.Add(new Nop_PricelistMap());
            modelBuilder.Configurations.Add(new Nop_ProductMap());
            modelBuilder.Configurations.Add(new Nop_Product_Category_MappingMap());
            modelBuilder.Configurations.Add(new Nop_Product_Manufacturer_MappingMap());
            modelBuilder.Configurations.Add(new Nop_Product_SpecificationAttribute_MappingMap());
            modelBuilder.Configurations.Add(new Nop_ProductAttributeMap());
            modelBuilder.Configurations.Add(new Nop_ProductAttributeLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_ProductLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_ProductPictureMap());
            modelBuilder.Configurations.Add(new Nop_ProductRatingMap());
            modelBuilder.Configurations.Add(new Nop_ProductReviewMap());
            modelBuilder.Configurations.Add(new Nop_ProductReviewHelpfulnessMap());
            modelBuilder.Configurations.Add(new Nop_ProductTagMap());
            modelBuilder.Configurations.Add(new Nop_ProductTemplateMap());
            modelBuilder.Configurations.Add(new Nop_ProductTypeMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariantMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariant_Pricelist_MappingMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariant_ProductAttribute_MappingMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariantAttributeCombinationMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariantAttributeValueMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariantAttributeValueLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_ProductVariantLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_QueuedEmailMap());
            modelBuilder.Configurations.Add(new Nop_RecurringPaymentMap());
            modelBuilder.Configurations.Add(new Nop_RecurringPaymentHistoryMap());
            modelBuilder.Configurations.Add(new Nop_RelatedProductMap());
            modelBuilder.Configurations.Add(new Nop_RewardPointsHistoryMap());
            modelBuilder.Configurations.Add(new Nop_SearchLogMap());
            modelBuilder.Configurations.Add(new Nop_SettingMap());
            modelBuilder.Configurations.Add(new Nop_ShippingByTotalMap());
            modelBuilder.Configurations.Add(new Nop_ShippingByWeightMap());
            modelBuilder.Configurations.Add(new Nop_ShippingByWeightAndCountryMap());
            modelBuilder.Configurations.Add(new Nop_ShippingMethodMap());
            modelBuilder.Configurations.Add(new Nop_ShippingRateComputationMethodMap());
            modelBuilder.Configurations.Add(new Nop_ShippingStatusMap());
            modelBuilder.Configurations.Add(new Nop_ShoppingCartItemMap());
            modelBuilder.Configurations.Add(new Nop_ShoppingCartTypeMap());
            modelBuilder.Configurations.Add(new Nop_SpecificationAttributeMap());
            modelBuilder.Configurations.Add(new Nop_SpecificationAttributeLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_SpecificationAttributeOptionMap());
            modelBuilder.Configurations.Add(new Nop_SpecificationAttributeOptionLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_StateProvinceMap());
            modelBuilder.Configurations.Add(new Nop_TaxCategoryMap());
            modelBuilder.Configurations.Add(new Nop_TaxProviderMap());
            modelBuilder.Configurations.Add(new Nop_TaxRateMap());
            modelBuilder.Configurations.Add(new Nop_TierPriceMap());
            modelBuilder.Configurations.Add(new Nop_TopicMap());
            modelBuilder.Configurations.Add(new Nop_TopicLocalizedMap());
            modelBuilder.Configurations.Add(new Nop_WarehouseMap());           
        }


        
    }
}
