using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using NetUtility;
using PigFarm.Helpers;
using PigFarm.Models;

#nullable disable

namespace PigFarm.Data
{
    public partial class PigFarmContext : DbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public PigFarmContext(DbContextOptions<PigFarmContext> options, IHttpContextAccessor contextAccessor = null) : base(options)
        {
            _contextAccessor = contextAccessor;
        }
        public virtual DbSet<RecordBuried> RecordBurieds { get; set; }
        public virtual DbSet<RecordChemical> RecordChemicals { get; set; }
        public virtual DbSet<RecordKill> RecordKills { get; set; }
        public virtual DbSet<RecordPigIn> RecordPigIns { get; set; }
        public virtual DbSet<RecordPigOut> RecordPigOuts { get; set; }
        public virtual DbSet<RecordSilo> RecordSilos { get; set; }
        public virtual DbSet<RecordStolen> RecordStolens { get; set; }

        public virtual DbSet<Record2Pen> Record2Pens { get; set; }
        public virtual DbSet<Record2Pig> Record2Pigs { get; set; }
        public virtual DbSet<Record2Room> Record2Rooms { get; set; }
        public virtual DbSet<RecordCulling> RecordCullings { get; set; }
        public virtual DbSet<RecordDeath> RecordDeaths { get; set; }
        public virtual DbSet<RecordDiagnosis> RecordDiagnoses { get; set; }
        public virtual DbSet<RecordDisinfection> RecordDisinfections { get; set; }
        public virtual DbSet<RecordDonate> RecordDonates { get; set; }
        public virtual DbSet<RecordEarTag> RecordEarTags { get; set; }
        public virtual DbSet<RecordFeeding> RecordFeedings { get; set; }
        public virtual DbSet<RecordGeneral> RecordGenerals { get; set; }
        public virtual DbSet<RecordImmunization> RecordImmunizations { get; set; }
        public virtual DbSet<RecordInOut> RecordInOuts { get; set; }
        public virtual DbSet<RecordInventoryCheck> RecordInventoryChecks { get; set; }
        public virtual DbSet<RecordMove> RecordMoves { get; set; }
        public virtual DbSet<RecordPatrol> RecordPatrols { get; set; }
        public virtual DbSet<RecordRepair> RecordRepairs { get; set; }
        public virtual DbSet<RecordSale> RecordSales { get; set; }
        public virtual DbSet<RecordTower> RecordTowers { get; set; }
        public virtual DbSet<RecordVectorControl> RecordVectorControls { get; set; }
        public virtual DbSet<RecordWeighing> RecordWeighings { get; set; }

        public virtual DbSet<RecordInOut2Pig> RecordInOut2Pigs { get; set; }
        public virtual DbSet<PigFarm.Models.PigFarmVectorControl> PigFarmVectorControls { get; set; }
        public virtual DbSet<Rfid> Rfids { get; set; }
        public virtual DbSet<Semen> Semen { get; set; }
        public virtual DbSet<SemenMix> SemenMixes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<AccountPermission> AccountPermissions { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Barn> Barns { get; set; }
        public virtual DbSet<Bom> Boms { get; set; }
        public virtual DbSet<BomDisinfection> BomDisinfections { get; set; }
        public virtual DbSet<BomFeed> BomFeeds { get; set; }
        public virtual DbSet<BomImmunization> BomImmunizations { get; set; }
        public virtual DbSet<BomMove> BomMoves { get; set; }
        public virtual DbSet<BomTreatment> BomTreatments { get; set; }
        public virtual DbSet<BomVectorControl> BomVectorControls { get; set; }
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<CodeHelp> CodeHelps { get; set; }
        public virtual DbSet<CodePermission> CodePermissions { get; set; }
        public virtual DbSet<CodePermission1> CodePermissions1 { get; set; }
        public virtual DbSet<CodeServiceType> CodeServiceTypes { get; set; }
        public virtual DbSet<CodeType> CodeTypes { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<CullingTank> CullingTanks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dashboard> Dashboards { get; set; }
        public virtual DbSet<DbPublicCodeType> DbPublicCodeTypes { get; set; }
        public virtual DbSet<DbPublicContact> DbPublicContacts { get; set; }
        public virtual DbSet<DbPublicCountyTownShip> DbPublicCountyTownShips { get; set; }
        public virtual DbSet<DbPublicFavorite> DbPublicFavorites { get; set; }
        public virtual DbSet<DbPublicGp> DbPublicGps { get; set; }
        public virtual DbSet<DbPublicMemo> DbPublicMemos { get; set; }
        public virtual DbSet<DbPublicNurse> DbPublicNurses { get; set; }
        public virtual DbSet<DbPublicPatient> DbPublicPatients { get; set; }
        public virtual DbSet<DbPublicPaymentCode> DbPublicPaymentCodes { get; set; }
        public virtual DbSet<DbPublicPhoto> DbPublicPhotos { get; set; }
        public virtual DbSet<DbPublicReaded> DbPublicReadeds { get; set; }
        public virtual DbSet<DbPublicWebPrint> DbPublicWebPrints { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Disinfection> Disinfections { get; set; }
        public virtual DbSet<EmailPool> EmailPools { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<FeedMaterial> FeedMaterials { get; set; }
        public virtual DbSet<Feeding> Feedings { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<JournalPhoto> JournalPhotos { get; set; }
        public virtual DbSet<MakeOrder> MakeOrders { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Method> Methods { get; set; }
        public virtual DbSet<MultiChoiceCountyTownShip> MultiChoiceCountyTownShips { get; set; }
        public virtual DbSet<MultiChoiceCountyTownShip1> MultiChoiceCountyTownShips1 { get; set; }
        public virtual DbSet<MultiChoicePaymentCode> MultiChoicePaymentCodes { get; set; }
        public virtual DbSet<Nutrition> Nutritions { get; set; }
        public virtual DbSet<Oc> Ocs { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Pen> Pens { get; set; }
        public virtual DbSet<Pig> Pigs { get; set; }
        public virtual DbSet<PigKind> PigKinds { get; set; }
        public virtual DbSet<PublicCodeType> PublicCodeTypes { get; set; }
        public virtual DbSet<PublicCountyTownShip> PublicCountyTownShips { get; set; }
        public virtual DbSet<PublicMemo> PublicMemos { get; set; }
        public virtual DbSet<PublicPaymentCode> PublicPaymentCodes { get; set; }
        public virtual DbSet<PublicReaded> PublicReadeds { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SysConfig> SysConfigs { get; set; }
        public virtual DbSet<SysLogGp> SysLogGps { get; set; }
        public virtual DbSet<SysLogUser> SysLogUsers { get; set; }
        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<SystemLanguage> SystemLanguages { get; set; }
        public virtual DbSet<SystemLogUser> SystemLogUsers { get; set; }
        public virtual DbSet<Township> Townships { get; set; }
        public virtual DbSet<UserConfig> UserConfigs { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public virtual DbSet<WebMenu> WebMenus { get; set; }
        public virtual DbSet<XAccount> XAccounts { get; set; }
        public virtual DbSet<XAccountGroup> XAccountGroups { get; set; }
        public virtual DbSet<XAccountPermission> XAccountPermissions { get; set; }
        public virtual DbSet<XAccountRole> XAccountRoles { get; set; }
        public virtual DbSet<XAccountSetting> XAccountSettings { get; set; }
        public virtual DbSet<XxxBom> XxxBoms { get; set; }
        public virtual DbSet<PigFarm.Models.PigHouseDisinfection> PigHouseDisinfections { get; set; }

        public virtual DbSet<BioS2pen> BioS2pens { get; set; }
        public virtual DbSet<BioS2pig> BioS2pigs { get; set; }
        public virtual DbSet<BioSMaster> BioSMasters { get; set; }
        public virtual DbSet<BioSRecord> BioSRecords { get; set; }


        public virtual DbSet<PigCode> PigCodes { get; set; }
        public virtual DbSet<PigGenetic> PigGenetics { get; set; }
        public virtual DbSet<PigPedigree> PigPedigrees { get; set; }
        public virtual DbSet<PigTesting> PigTestings { get; set; }

        public virtual DbSet<Acceptance> Acceptances { get; set; }
        public virtual DbSet<AcceptanceCheck> AcceptanceChecks { get; set; }
        public virtual DbSet<AcceptanceCheckIn> AcceptanceCheckIns { get; set; }
        public virtual DbSet<AcceptanceInspection> AcceptanceInspections { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryChange> InventoryChanges { get; set; }
        public virtual DbSet<InventoryScrap> InventoryScraps { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<RepairDetail> RepairDetails { get; set; }
        public virtual DbSet<RepairRecord> RepairRecords { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<RequisitionFeed> RequisitionFeeds { get; set; }
        public virtual DbSet<RequisitionMaterial> RequisitionMaterials { get; set; }
        public virtual DbSet<RequisitionMedicine> RequisitionMedicines { get; set; }
        public virtual DbSet<RequisitionThing> RequisitionThings { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderCheckOut> SalesOrderCheckOuts { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<Thing> Things { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<ReportConfig> ReportConfigs { get; set; }
        public virtual DbSet<PigFarm.Models.BomFeeding> BomFeedings { get; set; }

        public virtual DbSet<PigCulling> PigCullings { get; set; }
        public virtual DbSet<PigDiagnosis> PigDiagnoses { get; set; }
        public virtual DbSet<PigDisease2pen> PigDisease2pens { get; set; }
        public virtual DbSet<PigDisease2pig> PigDisease2pigs { get; set; }
        public virtual DbSet<PigFarmVector> PigFarmVectors { get; set; }
        public virtual DbSet<PigHouseCleaning> PigHouseCleanings { get; set; }
        public virtual DbSet<PigHouseCleaning2pen> PigHouseCleaning2pens { get; set; }
        public virtual DbSet<PigHouseCleaning2pig> PigHouseCleaning2pigs { get; set; }
        public virtual DbSet<PigHouseCleaningPlan> PigHouseCleaningPlans { get; set; }
        public virtual DbSet<PigHouseCleaningRecord> PigHouseCleaningRecords { get; set; }
        public virtual DbSet<PigHouseCleaningSchedule> PigHouseCleaningSchedules { get; set; }
        public virtual DbSet<PigFarmVector2pen> PigFarmVector2pens { get; set; }
        public virtual DbSet<PigFarmVector2pig> PigFarmVector2pigs { get; set; }
        public virtual DbSet<PigIsolation> PigIsolations { get; set; }
        public virtual DbSet<PigPrescription> PigPrescriptions { get; set; }
        public virtual DbSet<PigTreatment> PigTreatments { get; set; }
        public virtual DbSet<StoredProcedure> StoredProcedures { get; set; }
        public virtual DbSet<RecordCullingSale> RecordCullingSales { get; set; }

        public virtual DbSet<PigFarm.Models.BomWeighing> BomWeighings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RecordCullingSale>(entity =>
            {
                entity.ToTable("Record_CullingSale");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Customer_GUID");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.SalesOrderComment)
                    .HasColumnType("ntext")
                    .HasColumnName("SalesOrder_Comment");

                entity.Property(e => e.SalesOrderName)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_Name");

                entity.Property(e => e.SalesOrderNo)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_NO");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UploadDocument).HasMaxLength(100);

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");
                entity.Property(e => e.SalesOrderAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SalesOrder_Amount");
                entity.Property(e => e.SalesOrderWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SalesOrderWeight");



            });


            modelBuilder.Entity<RecordBuried>(entity =>
           {
               entity.ToTable("Record_Buried");

               entity.Property(e => e.Id).HasColumnName("ID");

               entity.Property(e => e.AgreeDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Agree_Date");

               entity.Property(e => e.AgreeGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Agree_GUID");

               entity.Property(e => e.AgreeReason)
                   .HasMaxLength(100)
                   .HasColumnName("Agree_Reason");

               entity.Property(e => e.ApplyDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Apply_Date");

               entity.Property(e => e.ApplyGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Apply_GUID");

               entity.Property(e => e.ApplyReason)
                   .HasMaxLength(100)
                   .HasColumnName("Apply_Reason");

               entity.Property(e => e.BuriedMethod)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("Buried_Method");

               entity.Property(e => e.BuriedReason)
                   .HasMaxLength(100)
                   .HasColumnName("Buried_Reason");

               entity.Property(e => e.BuriedWeight)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("Buried_Weight");

               entity.Property(e => e.Comment)
                   .HasColumnType("ntext")
                   .HasColumnName("COMMENT");

               entity.Property(e => e.CreateBy)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("CREATE_BY");

               entity.Property(e => e.CreateDate)
                   .HasColumnType("datetime")
                   .HasColumnName("CREATE_DATE");

               entity.Property(e => e.DeleteBy)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("DELETE_BY");

               entity.Property(e => e.DeleteDate)
                   .HasColumnType("datetime")
                   .HasColumnName("DELETE_DATE");

               entity.Property(e => e.EstDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EST_Date");

               entity.Property(e => e.ExecuteDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Execute_Date");

               entity.Property(e => e.ExecuteGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Execute_GUID");

               entity.Property(e => e.ExecuteReason)
                   .HasMaxLength(100)
                   .HasColumnName("Execute_Reason");

               entity.Property(e => e.FarmGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Farm_GUID");

               entity.Property(e => e.Guid)
                   .HasMaxLength(40)
                   .HasColumnName("GUID")
                   .HasDefaultValueSql("(newid())");

               entity.Property(e => e.MakeOrderGuid)
                   .HasMaxLength(40)
                   .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");
               entity.Property(e => e.RejectDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Reject_Date");

               entity.Property(e => e.RejectGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Reject_GUID");

               entity.Property(e => e.RejectReason)
                   .HasMaxLength(100)
                   .HasColumnName("Reject_Reason");

               entity.Property(e => e.Status)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("STATUS");

               entity.Property(e => e.Type)
                   .HasMaxLength(10)
                   .HasColumnName("TYPE");

               entity.Property(e => e.UpdateBy)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("UPDATE_BY");

               entity.Property(e => e.UpdateDate)
                   .HasColumnType("datetime")
                   .HasColumnName("UPDATE_DATE");
               
           });

            modelBuilder.Entity<RecordChemical>(entity =>
            {
                entity.ToTable("Record_Chemical");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.ChemicalMethod)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Chemical_Method");

                entity.Property(e => e.ChemicalReason)
                    .HasMaxLength(100)
                    .HasColumnName("Chemical_Reason");

                entity.Property(e => e.ChemicalWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Chemical_Weight");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordKill>(entity =>
            {
                entity.ToTable("Record_Kill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.KillMethod)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Kill_Method");

                entity.Property(e => e.KillReason)
                    .HasMaxLength(100)
                    .HasColumnName("Kill_Reason");

                entity.Property(e => e.KillWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Kill_Weight");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordPigIn>(entity =>
            {
                entity.ToTable("Record_PigIn");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FromFarm)
                    .HasMaxLength(40)
                    .HasColumnName("From_Farm");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InOutAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InOut_Amount");

                entity.Property(e => e.InOutDept)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Dept");

                entity.Property(e => e.InOutName)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_Name");

                entity.Property(e => e.InOutNo)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_NO");

                entity.Property(e => e.InOutReason)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Reason");

                entity.Property(e => e.InOutSource)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Source");

                entity.Property(e => e.InOutWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InOut_Weight");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PigInfor)
                    .HasMaxLength(40)
                    .HasColumnName("Pig_Infor");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToFarm)
                    .HasMaxLength(40)
                    .HasColumnName("To_Farm");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                
                entity.Property(e => e.VeterinaryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Veterinary_Date");

                entity.Property(e => e.VeterinaryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Veterinary_Reason");

               entity.Property(e => e.VeterinaryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Veterinary_GUID");
                
                entity.Property(e => e.SourceOrderNo)
                   .HasMaxLength(40)
                   .HasColumnName("Source_OrderNo");

                entity.Property(e => e.SourceAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Source_Amount");

                entity.Property(e => e.SourceTotalWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Source_TotalWeight");

                 entity.Property(e => e.RealAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Real_Amount");

                entity.Property(e => e.RealTotalWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Real_TotalWeight");
            });

            modelBuilder.Entity<RecordPigOut>(entity =>
            {
                entity.ToTable("Record_PigOut");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FromFarm)
                    .HasMaxLength(40)
                    .HasColumnName("From_Farm");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InOutAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InOut_Amount");

                entity.Property(e => e.InOutDept)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Dept");

                entity.Property(e => e.InOutName)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_Name");

                entity.Property(e => e.InOutNo)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_NO");

                entity.Property(e => e.InOutReason)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Reason");

                entity.Property(e => e.InOutSource)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_Source");

                entity.Property(e => e.InOutWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InOut_Weight");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PigInfor)
                    .HasMaxLength(40)
                    .HasColumnName("Pig_Infor");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToFarm)
                    .HasMaxLength(40)
                    .HasColumnName("To_Farm");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                entity.Property(e => e.VeterinaryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Veterinary_Date");

                entity.Property(e => e.VeterinaryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Veterinary_Reason");

               entity.Property(e => e.VeterinaryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Veterinary_GUID");
            });

            modelBuilder.Entity<RecordSilo>(entity =>
            {
                entity.ToTable("Record_Silo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstAmount)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("EST_Amount");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteAmount)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Execute_Amount");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteFeedGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_Feed_GUID");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FeedCost)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Feed_Cost");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.RealAmount)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Real_Amount");

                entity.Property(e => e.RecordNo)
                    .HasMaxLength(100)
                    .HasColumnName("Record_NO");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RemainingAmount)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Remaining_Amount");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");
            });

            modelBuilder.Entity<RecordStolen>(entity =>
            {
                entity.ToTable("Record_Stolen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.StolenAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Stolen_Amount");

                entity.Property(e => e.StolenName)
                    .HasMaxLength(100)
                    .HasColumnName("Stolen_Name");

                entity.Property(e => e.StolenNo)
                    .HasMaxLength(100)
                    .HasColumnName("Stolen_NO");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");
            });
            modelBuilder.Entity<Record2Pen>(entity =>
            {
                entity.ToTable("Record2PEN");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pen_GUID");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.Type).HasMaxLength(40);
            });

            modelBuilder.Entity<Record2Pig>(entity =>
            {
                entity.ToTable("Record2Pig");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.Type).HasMaxLength(40);
                entity.Property(e => e.RecordValue)
                    .HasMaxLength(40)
                    .HasColumnName("Record_Value");

                entity.Property(e => e.RecordWeight)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Record_Weight");

                entity.Property(e => e.RecordAmount)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Record_Amount");

                entity.Property(e => e.RecordDisease)
                    .HasMaxLength(40)
                    .HasColumnName("Record_Disease");

                entity.Property(e => e.RecordNext)
                    .HasMaxLength(40)
                    .HasColumnName("Record_Next");
            });

            modelBuilder.Entity<Record2Room>(entity =>
            {
                entity.ToTable("Record2ROOM");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.Type).HasMaxLength(40);
            });
            modelBuilder.Entity<RecordInOut2Pig>(entity =>
            {
                entity.ToTable("Record_InOut2Pig");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InOutGuid)
                    .HasMaxLength(40)
                    .HasColumnName("InOut_GUID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");
            });

            modelBuilder.Entity<PigFarm.Models.BomFeeding>(entity =>
            {


                entity.ToTable("BOM_Feeding");

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EstAmount)
                    .HasMaxLength(10)
                    .HasColumnName("EST_Amount");

                entity.Property(e => e.FeedGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Feed_GUID");

                entity.Property(e => e.FeedName)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Name");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Type");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordAmount)
                    .HasMaxLength(10)
                    .HasColumnName("Record_Amount");

                entity.Property(e => e.RecordResult)
                    .HasMaxLength(10)
                    .HasColumnName("Record_Result");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);
            });

            modelBuilder.Entity<BomWeighing>(entity =>
            {
                entity.ToTable("BOM_Weighing");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(10);

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);

                entity.Property(e => e.WeighingName)
                    .HasMaxLength(100)
                    .HasColumnName("Weighing_Name");

                entity.Property(e => e.WeighingType)
                    .HasMaxLength(100)
                    .HasColumnName("Weighing_Type");
                entity.Property(e => e.StandardWeight)
                .HasColumnType("numeric(18, 1)")
                .HasColumnName("StandardWeight");

            });

            modelBuilder.Entity<PigHouseDisinfection>(entity =>
            {
                entity.ToTable("PigHouse_Disinfection");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(40);

                entity.Property(e => e.Capacity).HasMaxLength(40);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.DisinfectionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Disinfection_GUID");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.EstTime)
                    .HasMaxLength(5)
                    .HasColumnName("EST_TIME");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(40);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");


                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UseType).HasMaxLength(40);

                entity.Property(e => e.UseUnit).HasMaxLength(40);

                entity.Property(e => e.PigGuid)
             .HasMaxLength(40)
             .HasColumnName("Pig_GUID");

                entity.Property(e => e.PenGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Pen_GUID");

                entity.Property(e => e.RoomGuid)
                        .HasMaxLength(40)
                        .HasColumnName("Room_GUID");

            });
            modelBuilder.Entity<PigFarmVectorControl>(entity =>
            {
                entity.ToTable("PigFarm_VectorControl");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(40);

                entity.Property(e => e.Capacity).HasMaxLength(40);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.EstTime)
                    .HasMaxLength(5)
                    .HasColumnName("EST_TIME");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(40);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UseType).HasMaxLength(40);

                entity.Property(e => e.UseUnit).HasMaxLength(40);

                entity.Property(e => e.VectorControlGuid)
                    .HasMaxLength(40)
                    .HasColumnName("VectorControl_GUID");

                entity.Property(e => e.PigGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Pig_GUID");

                entity.Property(e => e.PenGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Pen_GUID");
                entity.Property(e => e.RoomGuid)
                 .HasMaxLength(40)
                 .HasColumnName("Room_GUID");
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGroupId).HasColumnName("AccountGroupID");

                entity.Property(e => e.AccountRole)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Guid).HasMaxLength(40);

                entity.Property(e => e.LicensePath).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("NO");

                entity.Property(e => e.Ocid).HasColumnName("OCID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhotoPath).HasMaxLength(100);

                entity.Property(e => e.Rfid)
                    .HasMaxLength(20)
                    .HasColumnName("RFID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId);

                entity.HasOne(d => d.Oc)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Ocid);
            });

            modelBuilder.Entity<AccountGroup>(entity =>
            {
                entity.ToTable("AccountGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.GroupName).HasMaxLength(200);

                entity.Property(e => e.GroupNo)
                    .HasMaxLength(100)
                    .HasColumnName("GroupNO");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
            });

            modelBuilder.Entity<AccountPermission>(entity =>
            {
                entity.ToTable("AccountPermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CodeNO");

                entity.Property(e => e.UpperGuid).HasMaxLength(40);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPermissions)
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("AccountRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGuid).HasMaxLength(40);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CodeNO");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaLength)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Area_Length");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(200)
                    .HasColumnName("Area_Name");

                entity.Property(e => e.AreaNo)
                    .HasMaxLength(100)
                    .HasColumnName("Area_NO");

                entity.Property(e => e.AreaPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Area_Principal");

                entity.Property(e => e.AreaWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Area_Width");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmGgp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GGP");

                entity.Property(e => e.FarmGp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GP");

                entity.Property(e => e.FarmGrower)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GROWER");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FarmNursery)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_NURSERY");

                entity.Property(e => e.FarmPmpf)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_PMPF");

                entity.Property(e => e.FarmSemen)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_SEMEN");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Barn>(entity =>
            {
                entity.ToTable("Barn");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");

                entity.Property(e => e.BarnLength)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Barn_Length");

                entity.Property(e => e.BarnName)
                    .HasMaxLength(200)
                    .HasColumnName("Barn_Name");

                entity.Property(e => e.BarnNo)
                    .HasMaxLength(100)
                    .HasColumnName("Barn_NO");

                entity.Property(e => e.BarnPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Barn_Principal");

                entity.Property(e => e.BarnWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Barn_Width");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmGgp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GGP");

                entity.Property(e => e.FarmGp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GP");

                entity.Property(e => e.FarmGrower)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GROWER");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FarmNursery)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_NURSERY");

                entity.Property(e => e.FarmPmpf)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_PMPF");

                entity.Property(e => e.FarmSemen)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_SEMEN");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Bom>(entity =>
            {
                entity.ToTable("BOM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BomBreed)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_Breed");

                entity.Property(e => e.BomName)
                    .HasMaxLength(100)
                    .HasColumnName("BOM_NAME");

                entity.Property(e => e.BomNo)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_NO");

                entity.Property(e => e.BomType)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_Type");

                entity.Property(e => e.BomVersion)
                    .HasMaxLength(100)
                    .HasColumnName("BOM_VERSION");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<BomDisinfection>(entity =>
            {
                entity.ToTable("BOM_Disinfection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(40);

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Capacity).HasMaxLength(40);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DisinfectionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Disinfection_GUID");

                entity.Property(e => e.DisinfectionName)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Name");

                entity.Property(e => e.DisinfectionType)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Type");

                entity.Property(e => e.Frequency).HasMaxLength(40);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(40);

                entity.Property(e => e.UseUnit).HasMaxLength(40);
            });

            modelBuilder.Entity<BomFeed>(entity =>
            {
                entity.ToTable("BOM_Feed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FeedAvoid)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Avoid");

                entity.Property(e => e.FeedMaterial1)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Material1");

                entity.Property(e => e.FeedMaterial2)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Material2");

                entity.Property(e => e.FeedMaterial3)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Material3");

                entity.Property(e => e.FeedMaterial4)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Material4");

                entity.Property(e => e.FeedMaterial5)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Material5");

                entity.Property(e => e.FeedMethod)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Method");

                entity.Property(e => e.FeedName)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Name");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Type");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.MethodAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_Amount");

                entity.Property(e => e.MethodFreq)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_Freq");

                entity.Property(e => e.MethodType)
                    .HasMaxLength(10)
                    .HasColumnName("Method_Type");

                entity.Property(e => e.MethodUseTime)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_UseTIme");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<BomImmunization>(entity =>
            {
                entity.ToTable("BOM_Immunization");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(100);

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Capacity).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DiseaseGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Disease_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(100);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MedicineGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Medicine_GUID");

                entity.Property(e => e.Needle).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(100);

                entity.Property(e => e.UseUnit).HasMaxLength(100);
            });
            modelBuilder.Entity<BomMove>(entity =>
            {
                entity.ToTable("BOM_Move");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AfterPenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("AfterPen_GUID");

                entity.Property(e => e.ApplyDays).HasMaxLength(100);

                entity.Property(e => e.BeforePenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BeforePen_GUID");

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MoveInOut)
                    .HasMaxLength(20)
                    .HasColumnName("Move_InOut");

                entity.Property(e => e.MoveName)
                    .HasMaxLength(100)
                    .HasColumnName("Move_Name");

                entity.Property(e => e.MoveNo)
                    .HasMaxLength(100)
                    .HasColumnName("Move_NO");

                entity.Property(e => e.MoveType)
                    .HasMaxLength(10)
                    .HasColumnName("Move_Type");

                entity.Property(e => e.PigStatus)
                    .HasMaxLength(25)
                    .HasColumnName("Pig_Status");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });
            modelBuilder.Entity<BomTreatment>(entity =>
            {
                entity.ToTable("BOM_Treatment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.MethodAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_Amount");

                entity.Property(e => e.MethodFreq)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_Freq");

                entity.Property(e => e.MethodType)
                    .HasMaxLength(10)
                    .HasColumnName("Method_Type");

                entity.Property(e => e.MethodUseTime)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Method_UseTIme");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.TreatmentCare)
                    .HasMaxLength(100)
                    .HasColumnName("Treatment_care");

                entity.Property(e => e.TreatmentMedicine)
                    .HasMaxLength(100)
                    .HasColumnName("Treatment_Medicine");

                entity.Property(e => e.TreatmentMethod)
                    .HasMaxLength(100)
                    .HasColumnName("Treatment_Method");

                entity.Property(e => e.TreatmentName)
                    .HasMaxLength(100)
                    .HasColumnName("Treatment_Name");

                entity.Property(e => e.TreatmentType)
                    .HasMaxLength(100)
                    .HasColumnName("Treatment_Type");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<BomVectorControl>(entity =>
            {
                entity.ToTable("BOM_VectorControl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDays).HasMaxLength(10);

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Capacity).HasMaxLength(10);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);

                entity.Property(e => e.VectorControlGuid)
                    .HasMaxLength(40)
                    .HasColumnName("VectorControl_GUID");

                entity.Property(e => e.VectorControlName)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Name");

                entity.Property(e => e.VectorControlType)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Type");
            });

            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.ToTable("Bulletin");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AlwaysTop)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Always_Top")
                    .IsFixedLength(true);

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.BulletinDate).HasColumnType("datetime");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength(true);

                entity.Property(e => e.Link).HasColumnType("ntext");

                entity.Property(e => e.OrganizationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Organization_ID");

                entity.Property(e => e.SiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Site_ID");

                entity.Property(e => e.SortId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SORT_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subject).HasMaxLength(200);

                entity.Property(e => e.TypeId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Type_ID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.WebSiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("WebSite_ID");
            });

            modelBuilder.Entity<CodeHelp>(entity =>
            {
                entity.ToTable("CODE_HELP");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeNameCn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_CN");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_EN");

                entity.Property(e => e.CodeNameVn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_VN");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_TYPE");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<CodePermission>(entity =>
            {
                entity.ToTable("CODE_Permission");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME");

                entity.Property(e => e.CodeNameCn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_CN");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_EN");

                entity.Property(e => e.CodeNameVn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_VN");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_TYPE");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<CodePermission1>(entity =>
            {
                entity.ToTable("CodePermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodeNameCn)
                    .HasMaxLength(255)
                    .HasColumnName("CodeNameCN");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("CodeNameEN");

                entity.Property(e => e.CodeNameVn)
                    .HasMaxLength(255)
                    .HasColumnName("CodeNameVN");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("NO");

                entity.Property(e => e.Type).HasMaxLength(25);
            });

            modelBuilder.Entity<CodeServiceType>(entity =>
            {
                entity.ToTable("CODE_ServiceType");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.ToTable("CODE_TYPE");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME");

                entity.Property(e => e.CodeNameCn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_CN");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_EN");

                entity.Property(e => e.CodeNameVn)
                    .HasMaxLength(255)
                    .HasColumnName("CODE_NAME_VN");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.CodeType1)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_TYPE");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StoreId).HasColumnName("Store_id");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.WebSiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("WebSite_ID");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("COUNTY");

                entity.Property(e => e.CountyId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("COUNTY_ID")
                    .HasComment("縣市代號");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .HasComment("刪除旗標；Y -刪除,N - 未刪除");

                entity.Property(e => e.Cmt)
                    .HasMaxLength(255)
                    .HasColumnName("CMT")
                    .HasComment("備註");

                entity.Property(e => e.CountyName)
                    .HasMaxLength(255)
                    .HasColumnName("COUNTY_NAME")
                    .HasComment("縣市名稱");

                entity.Property(e => e.CountyNameOld)
                    .HasMaxLength(255)
                    .HasColumnName("COUNTY_NAME_OLD")
                    .HasComment("舊縣市名稱");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY")
                    .HasComment(" 建立人員");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasComment("建立日期");

                entity.Property(e => e.SigningId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SIGNING_ID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY")
                    .HasComment(" 更新人員");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasComment(" 更新日期");
            });

            modelBuilder.Entity<CullingTank>(entity =>
            {
                entity.ToTable("CullingTank");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CullingTankLength)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CullingTank_Length");

                entity.Property(e => e.CullingTankName)
                    .HasMaxLength(200)
                    .HasColumnName("CullingTank_Name");

                entity.Property(e => e.CullingTankNo)
                    .HasMaxLength(100)
                    .HasColumnName("CullingTank_NO");

                entity.Property(e => e.CullingTankPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("CullingTank_Principal");

                entity.Property(e => e.CullingTankWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CullingTank_Width");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_EMAIL");

                entity.Property(e => e.ContactMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_MOBILE");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.ContactTel)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_TEL");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_ADDRESS");

                entity.Property(e => e.CustomerBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("Customer_BIRTHDAY");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_EMAIL");

                entity.Property(e => e.CustomerIdcard)
                    .HasMaxLength(20)
                    .HasColumnName("Customer_IDCARD");

                entity.Property(e => e.CustomerMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Customer_MOBILE");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_NAME");

                entity.Property(e => e.CustomerNickname)
                    .HasMaxLength(20)
                    .HasColumnName("Customer_NICKNAME");

                entity.Property(e => e.CustomerNo)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_NO");

                entity.Property(e => e.CustomerSex)
                    .HasMaxLength(1)
                    .HasColumnName("Customer_SEX");

                entity.Property(e => e.CustomerTel)
                    .HasMaxLength(20)
                    .HasColumnName("Customer_TEL");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Dashboard>(entity =>
            {
                entity.ToTable("Dashboard");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(100)
                    .HasColumnName("Area_Name");
                entity.Property(e => e.LangID)
                                   .HasMaxLength(10)
                                   .HasColumnName("LangID");
                entity.Property(e => e.AreaNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Area_No");

                entity.Property(e => e.BackGroundColor).HasMaxLength(100);

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DashBoardName)
                    .HasMaxLength(100)
                    .HasColumnName("DashBoard_Name");

                entity.Property(e => e.DashBoardNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DashBoard_No");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(100)
                    .HasColumnName("Item_Name");

                entity.Property(e => e.ItemNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Item_No");

                entity.Property(e => e.SortId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Sort_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Text01).HasMaxLength(100);

                entity.Property(e => e.Text02).HasMaxLength(100);

                entity.Property(e => e.Text03).HasMaxLength(100);

                entity.Property(e => e.Text04).HasMaxLength(100);

                entity.Property(e => e.Text05).HasMaxLength(100);

                entity.Property(e => e.Text06).HasMaxLength(100);

                entity.Property(e => e.Text07).HasMaxLength(100);

                entity.Property(e => e.Text08).HasMaxLength(100);

                entity.Property(e => e.Text09).HasMaxLength(100);

                entity.Property(e => e.Text10).HasMaxLength(100);

                entity.Property(e => e.TextColor01).HasMaxLength(100);

                entity.Property(e => e.TextColor02).HasMaxLength(100);

                entity.Property(e => e.TextColor03).HasMaxLength(100);

                entity.Property(e => e.TextColor04).HasMaxLength(100);

                entity.Property(e => e.TextColor05).HasMaxLength(100);

                entity.Property(e => e.TextColor06).HasMaxLength(100);

                entity.Property(e => e.TextColor07).HasMaxLength(100);

                entity.Property(e => e.TextColor08).HasMaxLength(100);

                entity.Property(e => e.TextColor09).HasMaxLength(100);

                entity.Property(e => e.TextColor10).HasMaxLength(100);
                entity.Property(e => e.ChartTitle).HasColumnName("Chart_Title").HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.UpperArea)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Area");

                entity.Property(e => e.UpperDashBoard)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_DashBoard");

                entity.Property(e => e.Value01).HasMaxLength(100);

                entity.Property(e => e.Value02).HasMaxLength(100);

                entity.Property(e => e.Value03).HasMaxLength(100);

                entity.Property(e => e.Value04).HasMaxLength(100);

                entity.Property(e => e.Value05).HasMaxLength(100);

                entity.Property(e => e.Value06).HasMaxLength(100);

                entity.Property(e => e.Value07).HasMaxLength(100);

                entity.Property(e => e.Value08).HasMaxLength(100);

                entity.Property(e => e.Value09).HasMaxLength(100);

                entity.Property(e => e.Value10).HasMaxLength(100);

                entity.Property(e => e.ValueColor01).HasMaxLength(100);

                entity.Property(e => e.ValueColor02).HasMaxLength(100);

                entity.Property(e => e.ValueColor03).HasMaxLength(100);

                entity.Property(e => e.ValueColor04).HasMaxLength(100);

                entity.Property(e => e.ValueColor05).HasMaxLength(100);

                entity.Property(e => e.ValueColor06).HasMaxLength(100);

                entity.Property(e => e.ValueColor07).HasMaxLength(100);

                entity.Property(e => e.ValueColor08).HasMaxLength(100);

                entity.Property(e => e.ValueColor09).HasMaxLength(100);

                entity.Property(e => e.ValueColor10).HasMaxLength(100);
            });

            modelBuilder.Entity<DbPublicCodeType>(entity =>
            {
                entity.ToTable("dbPublic_Code_Type");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(40)
                    .HasColumnName("Code_NO");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(40)
                    .HasColumnName("Code_Type");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Temp).HasColumnName("temp");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicContact>(entity =>
            {
                entity.ToTable("dbPublic_Contact");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_Address");

                entity.Property(e => e.ContactDepartment)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_Department");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Email");

                entity.Property(e => e.ContactFax)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Fax");

                entity.Property(e => e.ContactJobTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_JobTitle");

                entity.Property(e => e.ContactMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Mobile");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.ContactNameEn)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_Name_EN");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_NO");

                entity.Property(e => e.ContactTel)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Tel");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Memo).HasColumnType("ntext");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicCountyTownShip>(entity =>
            {
                entity.ToTable("dbPublic_CountyTownShip");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CountyId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("County_ID");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TownShipId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TownShip_ID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicFavorite>(entity =>
            {
                entity.ToTable("dbPublic_Favorite");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("ACCOUNT_GUID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicGp>(entity =>
            {
                entity.ToTable("dbPublic_GPS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Lat)
                    .HasMaxLength(20)
                    .HasColumnName("LAT");

                entity.Property(e => e.Lng)
                    .HasMaxLength(20)
                    .HasColumnName("LNG");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicMemo>(entity =>
            {
                entity.ToTable("dbPublic_Memo");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Memo).HasColumnType("ntext");

                entity.Property(e => e.MemoDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Memo_Date");

                entity.Property(e => e.MemoProject)
                    .HasMaxLength(100)
                    .HasColumnName("Memo_Project");

                entity.Property(e => e.MemoYearsEnd)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Memo_Years_End");

                entity.Property(e => e.MemoYearsStart)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Memo_Years_Start");

                entity.Property(e => e.TempFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TEMP_Flag")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicNurse>(entity =>
            {
                entity.ToTable("dbPublic_Nurse");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.NurseGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Nurse_GUID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicPatient>(entity =>
            {
                entity.ToTable("dbPublic_Patient");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.PatientGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Patient_GUID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicPaymentCode>(entity =>
            {
                entity.ToTable("dbPublic_PaymentCode");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("ACCOUNT_GUID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.PaymentCode).HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicPhoto>(entity =>
            {
                entity.ToTable("dbPublic_Photo");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(100)
                    .HasColumnName("Photo_Path");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicReaded>(entity =>
            {
                entity.ToTable("dbPublic_Readed");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("ACCOUNT_GUID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<DbPublicWebPrint>(entity =>
            {
                entity.ToTable("dbPublic_WebPrint");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DiseaseCare)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_Care");

                entity.Property(e => e.DiseaseEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_Effect");

                entity.Property(e => e.DiseaseElement)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_Element");

                entity.Property(e => e.DiseaseName)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_Name");

                entity.Property(e => e.DiseaseNo)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_NO");

                entity.Property(e => e.DiseaseType)
                    .HasMaxLength(100)
                    .HasColumnName("Disease_Type");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Disinfection>(entity =>
            {
                entity.ToTable("Disinfection");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DisinfectionBreed)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Breed");

                entity.Property(e => e.DisinfectionCare)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Care");

                entity.Property(e => e.DisinfectionEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Effect");

                entity.Property(e => e.DisinfectionElement)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Element");

                entity.Property(e => e.DisinfectionName)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Name");

                entity.Property(e => e.DisinfectionNo)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_NO");

                entity.Property(e => e.DisinfectionRange)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Range");

                entity.Property(e => e.DisinfectionSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_SideEffect");

                entity.Property(e => e.DisinfectionType)
                    .HasMaxLength(100)
                    .HasColumnName("Disinfection_Type");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.DeleteBy)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("DELETE_BY");
                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");
                entity.Property(e => e.ExpireDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");

                entity.Property(e => e.Price)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Amount)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("AMOUNT");

                entity.Property(e => e.Cost)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("COST");
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<EmailPool>(entity =>
            {
                entity.ToTable("Email_Pool");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FromEmail).HasMaxLength(200);

                entity.Property(e => e.FromName).HasMaxLength(200);

                entity.Property(e => e.SendBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEND_BY");

                entity.Property(e => e.SendDate1)
                    .HasColumnType("datetime")
                    .HasColumnName("SEND_DATE");

                entity.Property(e => e.Senddate)
                    .HasColumnType("datetime")
                    .HasColumnName("SENDDATE");

                entity.Property(e => e.Sendto)
                    .HasMaxLength(200)
                    .HasColumnName("SENDTO");

                entity.Property(e => e.Sendtobcc)
                    .HasMaxLength(200)
                    .HasColumnName("SENDTOBCC");

                entity.Property(e => e.Sendtocc)
                    .HasMaxLength(200)
                    .HasColumnName("SENDTOCC");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength(true);

                entity.Property(e => e.Subject).HasMaxLength(200);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("numeric(18, 0)").HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.AddressDomicile).HasMaxLength(100);

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.ContactTel).HasMaxLength(20);

                entity.Property(e => e.Dept).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Idcard)
                    .HasMaxLength(20)
                    .HasColumnName("IDCard");

                entity.Property(e => e.Sex).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Level).HasMaxLength(20);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.NickName).HasMaxLength(20);

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("NO");
                entity.Property(e => e.FarmGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Farm_GUID");
                entity.Property(e => e.Tel).HasMaxLength(20);

                entity.Property(e => e.Unit).HasMaxLength(100);
                entity.Property(e => e.Guid)
                   .HasMaxLength(40)
                   .HasColumnName("GUID")
                   .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CreateBy");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDate");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UpdateBy");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdateDate");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.ToTable("Farm");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Farm_Address");

                entity.Property(e => e.FarmGgp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GGP");

                entity.Property(e => e.FarmGp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GP");

                entity.Property(e => e.FarmGrower)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GROWER");

                entity.Property(e => e.FarmLength)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_Length");

                entity.Property(e => e.FarmName)
                    .HasMaxLength(200)
                    .HasColumnName("Farm_Name");

                entity.Property(e => e.FarmNo)
                    .HasMaxLength(100)
                    .HasColumnName("Farm_NO");

                entity.Property(e => e.FarmNursery)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_NURSERY");

                entity.Property(e => e.FarmPmpf)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_PMPF");

                entity.Property(e => e.FarmPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Farm_Principal");

                entity.Property(e => e.FarmSemen)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_SEMEN");

                entity.Property(e => e.FarmTel)
                    .HasMaxLength(100)
                    .HasColumnName("Farm_Tel");

                entity.Property(e => e.FarmWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_Width");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .HasColumnName("longitude");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.TemptureLowLimit)
                    .HasMaxLength(20)
                    .HasColumnName("Tempture_LowLimit");

                entity.Property(e => e.TemptureTopLimit)
                    .HasMaxLength(20)
                    .HasColumnName("Tempture_TopLimit");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.ToTable("Feed");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");
                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");
                entity.Property(e => e.FeedBreed)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Breed");

                entity.Property(e => e.FeedCare)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Care");

                entity.Property(e => e.FeedEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Effect");

                entity.Property(e => e.FeedElement)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Element");

                entity.Property(e => e.FeedName)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Name");

                entity.Property(e => e.FeedNo)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_NO");

                entity.Property(e => e.FeedRange)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Range");

                entity.Property(e => e.FeedSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_SideEffect");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(100)
                    .HasColumnName("Feed_Type");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.ExpireDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");

                entity.Property(e => e.Price)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Amount)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("AMOUNT");

                entity.Property(e => e.Cost)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("COST");
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<FeedMaterial>(entity =>
            {
                entity.ToTable("FeedMaterial");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FeedMaterialBreed)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Breed");

                entity.Property(e => e.FeedMaterialCare)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Care");

                entity.Property(e => e.FeedMaterialEffect)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Effect");

                entity.Property(e => e.FeedMaterialElement)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Element");

                entity.Property(e => e.FeedMaterialName)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Name");

                entity.Property(e => e.FeedMaterialNo)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_NO");

                entity.Property(e => e.FeedMaterialRange)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Range");

                entity.Property(e => e.FeedMaterialSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_SideEffect");

                entity.Property(e => e.FeedMaterialType)
                    .HasMaxLength(100)
                    .HasColumnName("FeedMaterial_Type");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.ExpireDate)
                  .HasColumnType("datetime")
                  .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");

                entity.Property(e => e.Price)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Amount)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("AMOUNT");

                entity.Property(e => e.Cost)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("COST");
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<Feeding>(entity =>
            {
                entity.ToTable("Feeding");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("Journal");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.JournalBody)
                    .HasColumnType("ntext")
                    .HasColumnName("Journal_Body");

                entity.Property(e => e.JournalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Journal_Date");

                entity.Property(e => e.JournalDay)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Journal_Day");

                entity.Property(e => e.JournalMonth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Journal_Month");

                entity.Property(e => e.JournalSubject)
                    .HasMaxLength(100)
                    .HasColumnName("Journal_Subject");

                entity.Property(e => e.JournalYear)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Journal_Year");

                entity.Property(e => e.NurseGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Nurse_GUID");

                entity.Property(e => e.OrganizationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Organization_ID");

                entity.Property(e => e.PatientGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Patient_GUID");

                entity.Property(e => e.SiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Site_ID");

                entity.Property(e => e.TempFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TEMP_Flag")
                    .IsFixedLength(true);

                entity.Property(e => e.Temperature).HasColumnType("numeric(18, 8)");

                entity.Property(e => e.Temperature1).HasColumnType("numeric(18, 8)");

                entity.Property(e => e.Temperature1Time)
                    .HasMaxLength(10)
                    .HasColumnName("Temperature1_Time");

                entity.Property(e => e.Temperature2).HasColumnType("numeric(18, 8)");

                entity.Property(e => e.Temperature2Time)
                    .HasMaxLength(10)
                    .HasColumnName("Temperature2_Time");

                entity.Property(e => e.Temperature3).HasColumnType("numeric(18, 8)");

                entity.Property(e => e.Temperature3Time)
                    .HasMaxLength(10)
                    .HasColumnName("Temperature3_Time");

                entity.Property(e => e.TemperatureTime)
                    .HasMaxLength(10)
                    .HasColumnName("Temperature_Time");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<JournalPhoto>(entity =>
            {
                entity.ToTable("Journal_Photo");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(100)
                    .HasColumnName("Photo_Path");

                entity.Property(e => e.Reduced)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });
            modelBuilder.Entity<MakeOrder2Pen>(entity =>
            {
                entity.ToTable("MakeOrder2Pen");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");
            });
            modelBuilder.Entity<MakeOrder>(entity =>
            {
                entity.ToTable("MakeOrder");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.BomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BOM_GUID");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Close_Date");

                entity.Property(e => e.CloseGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Close_GUID");

                entity.Property(e => e.CloseReason)
                    .HasMaxLength(100)
                    .HasColumnName("Close_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CullingAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Culling_Amound");

                entity.Property(e => e.CurrentAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Current_Amound");

                entity.Property(e => e.CustomerGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Customer_GUID");

                entity.Property(e => e.DeathAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Death_Amound");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Delivery_Date");

                entity.Property(e => e.DonateAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Donate_Amound");

                entity.Property(e => e.EstimateEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Estimate_EndDate");

                entity.Property(e => e.EstimateStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Estimate_StartDate");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("In_Amound");

                entity.Property(e => e.OrderAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Order_Amound");

                entity.Property(e => e.OrderBreed)
                    .HasMaxLength(100)
                    .HasColumnName("Order_Breed");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.OrderFarm)
                    .HasMaxLength(100)
                    .HasColumnName("Order_Farm");

                entity.Property(e => e.OrderName)
                    .HasMaxLength(100)
                    .HasColumnName("Order_Name");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(100)
                    .HasColumnName("Order_NO");

                entity.Property(e => e.OrderPrice)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Order_Price");

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .HasColumnName("Order_Type");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RealEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Real_EndDate");

                entity.Property(e => e.RealStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Real_StartDate");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.SaleAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Sale_Amound");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.MedicineBreed)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Breed");

                entity.Property(e => e.MedicineCare)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Care");

                entity.Property(e => e.MedicineEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Effect");

                entity.Property(e => e.MedicineElement)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Element");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Name");

                entity.Property(e => e.MedicineNo)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_NO");

                entity.Property(e => e.MedicineRange)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Range");

                entity.Property(e => e.MedicineSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_SideEffect");

                entity.Property(e => e.MedicineType)
                    .HasMaxLength(100)
                    .HasColumnName("Medicine_Type");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");
                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");
                entity.Property(e => e.ExpireDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");

                entity.Property(e => e.Price)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Amount)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("AMOUNT");

                entity.Property(e => e.Cost)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("COST");
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<Method>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<MultiChoiceCountyTownShip>(entity =>
            {
                entity.ToTable("MultiChoice_CountyTownShip");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CountyId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("County_ID");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.TownShipId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TownShip_ID");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<MultiChoiceCountyTownShip1>(entity =>
            {
                entity.ToTable("MultiChoiceCountyTownShip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGuid).HasMaxLength(40);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.TownShipId).HasColumnName("TownShipID");

                entity.Property(e => e.UpperGuid).HasMaxLength(40);
            });

            modelBuilder.Entity<MultiChoicePaymentCode>(entity =>
            {
                entity.ToTable("MultiChoice_PaymentCode");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.ToTable("Nutrition");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.NutritionBreed)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Breed");

                entity.Property(e => e.NutritionCare)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Care");

                entity.Property(e => e.NutritionEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Effect");

                entity.Property(e => e.NutritionElement)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Element");

                entity.Property(e => e.NutritionName)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Name");

                entity.Property(e => e.NutritionNo)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_NO");

                entity.Property(e => e.NutritionRange)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Range");

                entity.Property(e => e.NutritionSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_SideEffect");

                entity.Property(e => e.NutritionType)
                    .HasMaxLength(100)
                    .HasColumnName("Nutrition_Type");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });
            modelBuilder.Entity<VectorControl>(entity =>
            {
                entity.ToTable("VectorControl");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.VectorControlBreed)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Breed");

                entity.Property(e => e.VectorControlCare)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Care");

                entity.Property(e => e.VectorControlEffect)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Effect");

                entity.Property(e => e.VectorControlElement)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Element");

                entity.Property(e => e.VectorControlName)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Name");

                entity.Property(e => e.VectorControlNo)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_NO");

                entity.Property(e => e.VectorControlRange)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Range");

                entity.Property(e => e.VectorControlSideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_SideEffect");

                entity.Property(e => e.VectorControlType)
                    .HasMaxLength(100)
                    .HasColumnName("VectorControl_Type");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                entity.Property(e => e.DeleteBy)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("DELETE_BY");
                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");
                entity.Property(e => e.ExpireDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");

                entity.Property(e => e.Price)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Amount)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("AMOUNT");

                entity.Property(e => e.Cost)
                  .HasColumnType("numeric(18, 0)")
                  .HasColumnName("COST");
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<Oc>(entity =>
            {
                entity.ToTable("OC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.Ggp).HasColumnName("GGP");

                entity.Property(e => e.Gp).HasColumnName("GP");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.No)
                    .HasMaxLength(100)
                    .HasColumnName("NO");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pmpf).HasColumnName("PMPF");

                entity.Property(e => e.Principal).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(20);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrganizationAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Organization_ADDRESS");

                entity.Property(e => e.OrganizationEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Organization_EMAIL");

                entity.Property(e => e.OrganizationMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Organization_MOBILE");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(200)
                    .HasColumnName("Organization_Name");

                entity.Property(e => e.OrganizationNo)
                    .HasMaxLength(100)
                    .HasColumnName("Organization_NO");

                entity.Property(e => e.OrganizationPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Organization_Principal");

                entity.Property(e => e.OrganizationTel)
                    .HasMaxLength(20)
                    .HasColumnName("Organization_TEL");

                entity.Property(e => e.OrganizationUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Organization_URL");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Pen>(entity =>
            {
                entity.ToTable("Pen");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");

                entity.Property(e => e.BarnGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Barn_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.PenLength)
                    .HasMaxLength(40)
                    .HasColumnName("Pen_Length");

                entity.Property(e => e.PenName)
                    .HasMaxLength(200)
                    .HasColumnName("Pen_Name");

                entity.Property(e => e.PenNo)
                    .HasMaxLength(100)
                    .HasColumnName("Pen_NO");

                entity.Property(e => e.PenPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Pen_Principal");

                entity.Property(e => e.PenWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Pen_Width");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });



            modelBuilder.Entity<PigKind>(entity =>
            {
                entity.ToTable("PigKind");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<PublicCodeType>(entity =>
            {
                entity.ToTable("PublicCodeType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.No)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NO");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PublicCountyTownShip>(entity =>
            {
                entity.ToTable("PublicCountyTownShip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CountryID");

                entity.Property(e => e.Guid).HasMaxLength(40);

                entity.Property(e => e.TownShip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpperGuid).HasMaxLength(40);
            });

            modelBuilder.Entity<PublicMemo>(entity =>
            {
                entity.ToTable("PublicMemo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Guid).HasMaxLength(40);

                entity.Property(e => e.Memo).HasColumnType("ntext");

                entity.Property(e => e.MemoProject).HasMaxLength(40);

                entity.Property(e => e.PaymentCode).HasMaxLength(40);

                entity.Property(e => e.TempFlag).HasColumnName("Temp_Flag");

                entity.Property(e => e.UpperGuid).HasMaxLength(40);
            });

            modelBuilder.Entity<PublicPaymentCode>(entity =>
            {
                entity.ToTable("PublicPaymentCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGuid).HasMaxLength(40);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.PaymentCode).HasMaxLength(40);

                entity.Property(e => e.UpperGuid).HasMaxLength(40);
            });

            modelBuilder.Entity<PublicReaded>(entity =>
            {
                entity.ToTable("PublicReaded");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGuid).HasMaxLength(40);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.UpperGuid).HasMaxLength(40);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Token);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                //entity.HasOne(d => d.Account)
                //    .WithMany(p => p.RefreshTokens)
                //    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");

                entity.Property(e => e.BarnGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Barn_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoomLength)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Room_Length");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(200)
                    .HasColumnName("Room_Name");

                entity.Property(e => e.RoomNo)
                    .HasMaxLength(100)
                    .HasColumnName("Room_NO");

                entity.Property(e => e.RoomPrincipal)
                    .HasMaxLength(200)
                    .HasColumnName("Room_Principal");

                entity.Property(e => e.RoomWidth)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Room_Width");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<SysConfig>(entity =>
            {
                entity.ToTable("SYS_CONFIG");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.ConfigNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CONFIG_NO");

                entity.Property(e => e.ConfigType)
                    .HasMaxLength(25)
                    .HasColumnName("CONFIG_TYPE");

                entity.Property(e => e.ConfigValue)
                    .HasMaxLength(255)
                    .HasColumnName("CONFIG_VALUE");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StoreId).HasColumnName("Store_id");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.WebSiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("WebSite_ID");
            });

            modelBuilder.Entity<SysLogGp>(entity =>
            {
                entity.ToTable("SYS_LOG_GPS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Action)
                    .HasMaxLength(30)
                    .HasColumnName("ACTION")
                    .IsFixedLength(true);

                entity.Property(e => e.CallBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(16)
                    .HasColumnName("IP");

                entity.Property(e => e.Lat)
                    .HasMaxLength(20)
                    .HasColumnName("LAT");

                entity.Property(e => e.Lng)
                    .HasMaxLength(20)
                    .HasColumnName("LNG");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");

                entity.Property(e => e.Wip)
                    .HasMaxLength(16)
                    .HasColumnName("WIP");
            });

            modelBuilder.Entity<SysLogUser>(entity =>
            {
                entity.HasKey(e => e.SluId)
                    .HasName("PK__SYS_LOG_USER__22");

                entity.ToTable("SYS_LOG_USER");

                entity.Property(e => e.SluId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SLU_ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Account_ID");

                entity.Property(e => e.SluDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SLU_DATE");

                entity.Property(e => e.SluFid)
                    .HasMaxLength(10)
                    .HasColumnName("SLU_FID");

                entity.Property(e => e.SluFunction).HasColumnName("SLU_FUNCTION");

                entity.Property(e => e.SluIp)
                    .HasMaxLength(16)
                    .HasColumnName("SLU_IP");

                entity.Property(e => e.SluModule)
                    .HasMaxLength(50)
                    .HasColumnName("SLU_MODULE");

                entity.Property(e => e.SluPage)
                    .HasMaxLength(50)
                    .HasColumnName("SLU_PAGE");

                entity.Property(e => e.SluSql).HasColumnName("SLU_SQL");

                entity.Property(e => e.SluText).HasColumnName("SLU_TEXT");

                entity.Property(e => e.SluTime)
                    .HasMaxLength(10)
                    .HasColumnName("SLU_TIME");

                entity.Property(e => e.SluType)
                    .HasMaxLength(30)
                    .HasColumnName("SLU_TYPE");

                entity.Property(e => e.SluUid)
                    .HasMaxLength(10)
                    .HasColumnName("SLU_UID");

                entity.Property(e => e.SluUrl).HasColumnName("SLU_URL");

                entity.Property(e => e.SluWip)
                    .HasMaxLength(16)
                    .HasColumnName("SLU_WIP");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("SYS_MENU");

                entity.Property(e => e.FarmGgp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GGP");

                entity.Property(e => e.FarmGp)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GP");

                entity.Property(e => e.FarmGrower)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_GROWER");
                entity.Property(e => e.FarmNursery)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_NURSERY");

                entity.Property(e => e.FarmPmpf)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_PMPF");

                entity.Property(e => e.FarmSemen)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Farm_SEMEN");


                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InFooter)
                    .HasMaxLength(1)
                    .HasColumnName("inFooter")
                    .IsFixedLength(true);

                entity.Property(e => e.InHeader)
                    .HasMaxLength(1)
                    .HasColumnName("inHeader")
                    .IsFixedLength(true);

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(200)
                    .HasColumnName("MenuICON");

                entity.Property(e => e.MenuIcon1)
                    .HasMaxLength(200)
                    .HasColumnName("MenuICON-1");

                entity.Property(e => e.MenuLink).HasMaxLength(200);

                entity.Property(e => e.MenuLinkEn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuLink_EN");

                entity.Property(e => e.MenuName).HasMaxLength(200);

                entity.Property(e => e.MenuNameEn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuName_EN");


                entity.Property(e => e.MenuNameCn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuName_CN");

                entity.Property(e => e.MenuNameVn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuName_VN");

                entity.Property(e => e.SortId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SORT_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPPER_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WebPageGuid)
                    .HasMaxLength(40)
                    .HasColumnName("WebPage_GUID");

                entity.Property(e => e.WebPageGuidEn)
                    .HasMaxLength(40)
                    .HasColumnName("WebPage_GUID_EN");
                entity.Property(e => e.StoredProceduresName)
                .HasMaxLength(200)
                .HasColumnName("StoredProceduresName");
                entity.Property(e => e.ReportType)
              .HasMaxLength(20)
              .HasColumnName("Report_Type");

                entity.Property(e => e.ChartName)
            .HasMaxLength(200)
            .HasColumnName("Chart_Name");

                entity.Property(e => e.ChartNameEn)
           .HasMaxLength(200)
           .HasColumnName("Chart_NameEn");

                entity.Property(e => e.ChartNameVn)
           .HasMaxLength(200)
           .HasColumnName("Chart_NameVn");

                entity.Property(e => e.ChartNameCn)
           .HasMaxLength(200)
           .HasColumnName("Chart_NameCn");

                entity.Property(e => e.ChartUnit)
         .HasMaxLength(20)
         .HasColumnName("Chart_Unit");

                entity.Property(e => e.ChartXAxisName)
       .HasMaxLength(200)
       .HasColumnName("Chart_XAxisName");

                entity.Property(e => e.ChartXAxisNameEn)
           .HasMaxLength(200)
           .HasColumnName("Chart_XAxisNameEn");

                entity.Property(e => e.ChartXAxisNameVn)
           .HasMaxLength(200)
           .HasColumnName("Chart_XAxisNameVn");

                entity.Property(e => e.ChartXAxisNameCn)
           .HasMaxLength(200)
           .HasColumnName("Chart_XAxisNameCn");


                entity.Property(e => e.ChartYAxisName)
        .HasMaxLength(200)
        .HasColumnName("Chart_YAxisName");

                entity.Property(e => e.ChartYAxisNameEn)
           .HasMaxLength(200)
           .HasColumnName("Chart_YAxisNameEn");

                entity.Property(e => e.ChartYAxisNameVn)
           .HasMaxLength(200)
           .HasColumnName("Chart_YAxisNameVn");

                entity.Property(e => e.ChartYAxisNameCn)
           .HasMaxLength(200)
           .HasColumnName("Chart_YAxisNameCn");

            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.ToTable("SystemConfig");

                entity.Property(e => e.Id)
                  .HasColumnType("numeric(18, 0)")
                  .ValueGeneratedOnAdd()
                  .HasColumnName("ID");

                entity.Property(e => e.AccountId)
         .HasColumnType("numeric(18, 0)")
         .HasColumnName("AccountID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.No)
                    .HasMaxLength(40)
                    .HasColumnName("NO");
                entity.Property(e => e.Link)
                    .HasMaxLength(200)
                    .HasColumnName("Link");

                entity.Property(e => e.Type).HasMaxLength(40);

                entity.Property(e => e.Value).HasMaxLength(40);

                entity.Property(e => e.Sort)
         .HasColumnType("numeric(18, 0)")
         .HasColumnName("Sort");

                entity.Property(e => e.WebBuildingId)
           .HasColumnType("numeric(18, 0)")
           .HasColumnName("WebBuildingID");

                entity.Property(e => e.CreateBy)
              .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Status)
                   .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<SystemLanguage>(entity =>
            {
                entity.ToTable("SystemLanguage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.Slcn)
                    .HasMaxLength(500)
                    .HasColumnName("SLCN");

                entity.Property(e => e.Slen)
                    .HasMaxLength(500)
                    .HasColumnName("SLEN");

                entity.Property(e => e.Slkey)
                    .HasMaxLength(50)
                    .HasColumnName("SLKey");

                entity.Property(e => e.Slpage)
                    .HasMaxLength(50)
                    .HasColumnName("SLPage");

                entity.Property(e => e.Sltw)
                    .HasMaxLength(500)
                    .HasColumnName("SLTW");

                entity.Property(e => e.Sltype)
                    .HasMaxLength(50)
                    .HasColumnName("SLType");

                entity.Property(e => e.Slvn)
                    .HasMaxLength(500)
                    .HasColumnName("SLVN");

                entity.Property(e => e.SystemMenuGuid)
                 .HasMaxLength(40)
                 .HasColumnName("SystemMenuGuid");

                entity.Property(e => e.CreateBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CREATE_BY")
                .HasComment("建立人員");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasComment("建立日期");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY")
                    .HasComment("更新人員");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasComment("更新日期");
                entity.Property(e => e.Status)
                   .HasColumnType("numeric(18, 0)")
                   .HasColumnName("STATUS");

            });

            modelBuilder.Entity<SystemLogUser>(entity =>
            {
                entity.ToTable("SystemLogUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cn)
                    .HasMaxLength(500)
                    .HasColumnName("CN");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.En)
                    .HasMaxLength(500)
                    .HasColumnName("EN");

                entity.Property(e => e.Key).HasMaxLength(50);

                entity.Property(e => e.Page).HasMaxLength(50);

                entity.Property(e => e.Tw)
                    .HasMaxLength(500)
                    .HasColumnName("TW");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Vn)
                    .HasMaxLength(500)
                    .HasColumnName("VN");
            });

            modelBuilder.Entity<Township>(entity =>
            {
                entity.ToTable("TOWNSHIP");

                entity.Property(e => e.TownshipId)
                    .HasMaxLength(60)
                    .HasColumnName("TOWNSHIP_ID")
                    .HasComment("鄉鎮市區代號");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG")
                    .HasComment("刪除旗標；Y -刪除,N - 未刪除");

                entity.Property(e => e.Cmt)
                    .HasMaxLength(255)
                    .HasColumnName("CMT")
                    .HasComment("備註");

                entity.Property(e => e.CountyId)
                    .HasMaxLength(60)
                    .HasColumnName("COUNTY_ID")
                    .HasComment("縣市代號");

                entity.Property(e => e.CountyIdOld)
                    .HasMaxLength(60)
                    .HasColumnName("COUNTY_ID_OLD")
                    .HasComment("舊縣市ID");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY")
                    .HasComment("建立人員");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasComment("建立日期");

                entity.Property(e => e.MlsId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MLS_ID");

                entity.Property(e => e.TownshipName)
                    .HasMaxLength(255)
                    .HasColumnName("TOWNSHIP_NAME")
                    .HasComment("鄉鎮區名稱");

                entity.Property(e => e.TownshipNameOld)
                    .HasMaxLength(255)
                    .HasColumnName("TOWNSHIP_NAME_OLD")
                    .HasComment("舊行政區名稱");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY")
                    .HasComment("更新人員");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasComment("更新日期");
            });

            modelBuilder.Entity<UserConfig>(entity =>
            {
                entity.ToTable("USER_CONFIG");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.ConfigNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CONFIG_NO");

                entity.Property(e => e.ConfigType)
                    .HasMaxLength(25)
                    .HasColumnName("CONFIG_TYPE");

                entity.Property(e => e.ConfigValue)
                    .HasMaxLength(255)
                    .HasColumnName("CONFIG_VALUE");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.OrganizationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Organization_ID");

                entity.Property(e => e.SiteId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Site_ID");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<WebMenu>(entity =>
            {
                entity.ToTable("WebMenu");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InFooter)
                    .HasMaxLength(1)
                    .HasColumnName("inFooter")
                    .IsFixedLength(true);

                entity.Property(e => e.InHeader)
                    .HasMaxLength(1)
                    .HasColumnName("inHeader")
                    .IsFixedLength(true);

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(200)
                    .HasColumnName("MenuICON");

                entity.Property(e => e.MenuIcon1)
                    .HasMaxLength(200)
                    .HasColumnName("MenuICON-1");

                entity.Property(e => e.MenuLink).HasMaxLength(200);

                entity.Property(e => e.MenuLinkEn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuLink_EN");

                entity.Property(e => e.MenuName).HasMaxLength(200);

                entity.Property(e => e.MenuNameEn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuName_EN");

                entity.Property(e => e.MenuNameVn)
                    .HasMaxLength(200)
                    .HasColumnName("MenuName_VN");

                entity.Property(e => e.SortId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SORT_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPPER_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WebPageGuid)
                    .HasMaxLength(40)
                    .HasColumnName("WebPage_GUID");

                entity.Property(e => e.WebPageGuidEn)
                    .HasMaxLength(40)
                    .HasColumnName("WebPage_GUID_EN");

                entity.Property(e => e.WebSiteId).HasColumnName("WebSite_id");
            });

            modelBuilder.Entity<XAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK_Account_12");

                entity.ToTable("xAccount");

                entity.Property(e => e.AccountId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Account_ID");

                entity.Property(e => e.AccountAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Account_ADDRESS");

                entity.Property(e => e.AccountBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("Account_BIRTHDAY");

                entity.Property(e => e.AccountDomicileAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Account_Domicile_ADDRESS");

                entity.Property(e => e.AccountEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Account_EMAIL");

                entity.Property(e => e.AccountGroup)
                    .HasMaxLength(100)
                    .HasColumnName("Account_Group");

                entity.Property(e => e.AccountIdcard)
                    .HasMaxLength(20)
                    .HasColumnName("Account_IDCARD");

                entity.Property(e => e.AccountMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Account_MOBILE");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(20)
                    .HasColumnName("Account_NAME");

                entity.Property(e => e.AccountNickname)
                    .HasMaxLength(20)
                    .HasColumnName("Account_NICKNAME");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(20)
                    .HasColumnName("Account_NO");

                entity.Property(e => e.AccountOrganization)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Account_Organization");

                entity.Property(e => e.AccountRole)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Account_Role")
                    .IsFixedLength(true);

                entity.Property(e => e.AccountSex)
                    .HasMaxLength(20)
                    .HasColumnName("Account_SEX");

                entity.Property(e => e.AccountSite)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Account_Site");

                entity.Property(e => e.AccountTel)
                    .HasMaxLength(20)
                    .HasColumnName("Account_TEL");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Account_Type")
                    .IsFixedLength(true);

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Clinic_ID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.ErrorLogin)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("errorLogin");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("FARM_GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmployeeGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Employee_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LastLogin_Date");

                entity.Property(e => e.Lastlogin)
                    .HasColumnType("datetime")
                    .HasColumnName("lastlogin");

                entity.Property(e => e.Lastuse)
                    .HasColumnType("datetime")
                    .HasColumnName("lastuse");

                entity.Property(e => e.PAccount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Account")
                    .IsFixedLength(true);

                entity.Property(e => e.PAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Admin")
                    .IsFixedLength(true);

                entity.Property(e => e.PClinic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Clinic")
                    .IsFixedLength(true);

                entity.Property(e => e.PCodeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_CodeType")
                    .IsFixedLength(true);

                entity.Property(e => e.PEnquiry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Enquiry")
                    .IsFixedLength(true);

                entity.Property(e => e.PEnquiryResult)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Enquiry_Result")
                    .IsFixedLength(true);

                entity.Property(e => e.PPatient)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_Patient")
                    .IsFixedLength(true);

                entity.Property(e => e.PPhotoComment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_PhotoComment")
                    .IsFixedLength(true);

                entity.Property(e => e.PRequisitionConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("P_RequisitionConfirm")
                    .IsFixedLength(true);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(100)
                    .HasColumnName("Photo_Path");

                entity.Property(e => e.RoleId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Role_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .HasColumnName("token");

                     entity.Property(e => e.AccessTokenLineNotify)
                    .HasMaxLength(200)
                    .HasColumnName("AccessTokenLineNotify");

                entity.Property(e => e.TypeId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Type_ID");

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .HasColumnName("UID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Upwd)
                    .HasMaxLength(50)
                    .HasColumnName("UPWD");
                entity.Property(e => e.PageSizeSetting)
                   .HasMaxLength(10)
                   .HasColumnName("PageSize_Setting");
            });

            modelBuilder.Entity<XAccountGroup>(entity =>
            {
                entity.ToTable("xAccount_Group");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(200)
                    .HasColumnName("Group_Name");

                entity.Property(e => e.GroupNo)
                    .HasMaxLength(100)
                    .HasColumnName("Group_NO");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<XAccountPermission>(entity =>
            {
                entity.ToTable("xAccount_Permission");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });
            modelBuilder.Entity<XAccountGroupPermission>(entity =>
            {
                entity.ToTable("xAccountGroup_Permission");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("UPPER_GUID");
            });
            modelBuilder.Entity<XAccountRole>(entity =>
            {
                entity.ToTable("xAccount_Role");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(25)
                    .HasColumnName("CODE_NO");
            });

            modelBuilder.Entity<XAccountSetting>(entity =>
            {
                entity.ToTable("xAccount_Setting");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(200)
                    .HasColumnName("Controller_Name");

                entity.Property(e => e.ControllerValue)
                    .HasMaxLength(200)
                    .HasColumnName("Controller_Value");

                entity.Property(e => e.Page).HasMaxLength(200);
            });

            modelBuilder.Entity<XxxBom>(entity =>
            {
                entity.ToTable("XXX_BOM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FeedingId).HasColumnName("FeedingID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.MethodId).HasColumnName("MethodID");

                entity.Property(e => e.PigKindId).HasColumnName("PigKindID");

                entity.Property(e => e.VaccineId).HasColumnName("VaccineID");

                entity.HasOne(d => d.Feeding)
                    .WithMany(p => p.XxxBoms)
                    .HasForeignKey(d => d.FeedingId)
                    .HasConstraintName("FK_BOM_Feeding_FeedingID");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.XxxBoms)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_BOM_Foods_FoodID");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.XxxBoms)
                    .HasForeignKey(d => d.MethodId)
                    .HasConstraintName("FK_BOM_Methods_MethodID");

                entity.HasOne(d => d.PigKind)
                    .WithMany(p => p.XxxBoms)
                    .HasForeignKey(d => d.PigKindId)
                    .HasConstraintName("FK_BOM_PigKind_PigKindID");

                entity.HasOne(d => d.Vaccine)
                    .WithMany(p => p.XxxBoms)
                    .HasForeignKey(d => d.VaccineId)
                    .HasConstraintName("FK_BOM_Vaccines_VaccineID");
            });

            #region Record
            modelBuilder.Entity<RecordCulling>(entity =>
            {
                entity.ToTable("Record_Culling");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CullingMethod)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Culling_Method");

                entity.Property(e => e.CullingReason)
                    .HasMaxLength(100)
                    .HasColumnName("Culling_Reason");

                entity.Property(e => e.CullingWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Culling_Weight");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordDeath>(entity =>
            {
                entity.ToTable("Record_Death");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeathMethod)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Death_Method");

                entity.Property(e => e.DeathReason)
                    .HasMaxLength(100)
                    .HasColumnName("Death_Reason");

                entity.Property(e => e.DeathWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Death_Weight");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordDisinfection>(entity =>
            {
                entity.ToTable("Record_Disinfection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyDays).HasMaxLength(10);

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Capacity).HasMaxLength(10);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.DisinfectionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Disinfection_GUID");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);

                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");

                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");
                entity.Property(e => e.BarnGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Barn_GUID");
            });

            modelBuilder.Entity<RecordDonate>(entity =>
            {
                entity.ToTable("Record_Donate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.DonateComment)
                    .HasColumnType("ntext")
                    .HasColumnName("Donate_Comment");

                entity.Property(e => e.DonateName)
                    .HasMaxLength(100)
                    .HasColumnName("Donate_Name");

                entity.Property(e => e.DonateNo)
                    .HasMaxLength(100)
                    .HasColumnName("Donate_NO");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UploadDocument)
                    .HasMaxLength(100)
                    .HasColumnName("UploadDocument");

                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");

                entity.Property(e => e.DonateAmound)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Donate_Amound");
            });

            modelBuilder.Entity<RecordEarTag>(entity =>
            {
                entity.ToTable("Record_EarTag");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EarNo).HasMaxLength(40);

                entity.Property(e => e.EarTagNo).HasMaxLength(40);

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Rfid)
                    .HasMaxLength(40)
                    .HasColumnName("RFID");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                
                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");
            });

            modelBuilder.Entity<RecordDiagnosis>(entity =>
            {
                entity.ToTable("Record_Diagnosis");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.Diagnosis).HasMaxLength(100);

                entity.Property(e => e.DiagnosisAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Diagnosis_Amount");

                entity.Property(e => e.DiagnosisCheck)
                    .HasMaxLength(100)
                    .HasColumnName("Diagnosis_Check");

                entity.Property(e => e.DiagnosisDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Diagnosis_Date");

                entity.Property(e => e.DiagnosisDescribe)
                    .HasMaxLength(100)
                    .HasColumnName("Diagnosis_Describe");

                entity.Property(e => e.DiagnosisDoctor)
                    .HasMaxLength(40)
                    .HasColumnName("Diagnosis_Doctor");

                entity.Property(e => e.DiagnosisDose)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Diagnosis_Dose");

                entity.Property(e => e.DiagnosisFirstDosDay)
                    .HasColumnType("datetime")
                    .HasColumnName("Diagnosis_FirstDosDay");

                entity.Property(e => e.DiagnosisMedicine)
                    .HasMaxLength(40)
                    .HasColumnName("Diagnosis_Medicine");

                entity.Property(e => e.DiagnosisNo)
                    .HasMaxLength(100)
                    .HasColumnName("Diagnosis_NO");

                entity.Property(e => e.DiagnosisPhysician)
                    .HasMaxLength(40)
                    .HasColumnName("Diagnosis_Physician");

                entity.Property(e => e.DiagnosisSymptom)
                    .HasMaxLength(100)
                    .HasColumnName("Diagnosis_Symptom");

                entity.Property(e => e.DiagnosisTimes)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Diagnosis_Times");

                entity.Property(e => e.DiagnosisTreatment)
                    .HasMaxLength(100)
                    .HasColumnName("Diagnosis_Treatment");

                entity.Property(e => e.DiagnosisWay)
                    .HasMaxLength(40)
                    .HasColumnName("Diagnosis_Way");

                entity.Property(e => e.DiagnosisWithdrawalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Diagnosis_WithdrawalDate");

                entity.Property(e => e.DiagnosisWithdrawalDays)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Diagnosis_WithdrawalDays");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InventoryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Inventory_GUID");

                entity.Property(e => e.InventoryReason)
                    .HasMaxLength(100)
                    .HasColumnName("Inventory_Reason");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.VeterinaryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Veterinary_Date");

                entity.Property(e => e.VeterinaryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Veterinary_GUID");

                entity.Property(e => e.VeterinaryReason)
                    .HasMaxLength(100)
                    .HasColumnName("Veterinary_Reason");
            });

            modelBuilder.Entity<RecordFeeding>(entity =>
            {
                entity.ToTable("Record_Feeding");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstAmount)
                    .HasMaxLength(10)
                    .HasColumnName("EST_Amount");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FeedGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Feed_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IntakeAverage)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Intake_Average");

                entity.Property(e => e.IntakeReal)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Intake_Real");

                entity.Property(e => e.IntakeStandard)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("Intake_Standard");

                entity.Property(e => e.MakeOrderAmound)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("MakeOrder_Amound");

                entity.Property(e => e.MakeOrderDayAge)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("MakeOrder_DayAge");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RecordAmount)
                    .HasMaxLength(10)
                    .HasColumnName("Record_Amount");

                entity.Property(e => e.RecordResult)
                    .HasMaxLength(10)
                    .HasColumnName("Record_Result");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);
            });

            modelBuilder.Entity<RecordGeneral>(entity =>
            {
                entity.ToTable("Record_General");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordImmunization>(entity =>
            {
                entity.ToTable("Record_Immunization");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyDays).HasMaxLength(100);

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Capacity).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.DiseaseGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Disease_GUID");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(100);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.MedicineGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Medicine_GUID");

                entity.Property(e => e.Needle).HasMaxLength(100);

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(100);

                entity.Property(e => e.UseUnit).HasMaxLength(100);

                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");
                
                 entity.Property(e => e.VeterinaryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Veterinary_Date");

                entity.Property(e => e.VeterinaryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Veterinary_Reason");

               entity.Property(e => e.VeterinaryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Veterinary_GUID");
            });

            modelBuilder.Entity<RecordInOut>(entity =>
            {
                entity.ToTable("Record_InOut");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FromFarm)
                    .HasMaxLength(40)
                    .HasColumnName("From_Farm");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InOutName)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_Name");

                entity.Property(e => e.InOutNo)
                    .HasMaxLength(100)
                    .HasColumnName("InOut_NO");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToFarm)
                    .HasMaxLength(40)
                    .HasColumnName("To_Farm");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");


                entity.Property(e => e.InOutWeight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InOut_Weight");
                entity.Property(e => e.InOutAmount)
                                    .HasColumnType("numeric(18, 0)")
                                    .HasColumnName("InOut_Amount");

                entity.Property(e => e.PigInfor)
                  .HasMaxLength(40)
                  .HasColumnName("Pig_Infor");
                entity.Property(e => e.InOutReason)

                                    .HasMaxLength(40)
                                    .HasColumnName("InOut_Reason");
                entity.Property(e => e.InOutSource)

                                  .HasMaxLength(40)
                                  .HasColumnName("InOut_Source");

                entity.Property(e => e.InOutDept)
                                    .HasMaxLength(40)
                                    .HasColumnName("InOut_Dept");
            });

            modelBuilder.Entity<RecordInventoryCheck>(entity =>
            {
                entity.ToTable("Record_InventoryCheck");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InventoryCheckAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("InventoryCheck_Amount");

                entity.Property(e => e.InventoryCheckName)
                    .HasMaxLength(100)
                    .HasColumnName("InventoryCheck_Name");

                entity.Property(e => e.InventoryCheckNo)
                    .HasMaxLength(100)
                    .HasColumnName("InventoryCheck_NO");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                entity.Property(e => e.FinanceDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Finance_Date");

                entity.Property(e => e.FinanceReason)
                   .HasMaxLength(100)
                   .HasColumnName("Finance_Reason");

               entity.Property(e => e.FinanceGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Finance_GUID");
            });

            modelBuilder.Entity<RecordMove>(entity =>
            {
                entity.ToTable("Record_Move");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AfterPenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("AfterPen_GUID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyDays).HasMaxLength(100);

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.BeforePenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BeforePen_GUID");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.MoveInOut)
                    .HasMaxLength(20)
                    .HasColumnName("Move_InOut");

                entity.Property(e => e.MoveType)
                    .HasMaxLength(10)
                    .HasColumnName("Move_Type");


                entity.Property(e => e.PigStatus)
                    .HasMaxLength(25)
                    .HasColumnName("Pig_Status");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.DelayDays)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Delay_Days");

                entity.Property(e => e.DelayReason)
                    .HasMaxLength(100)
                    .HasColumnName("Delay_Reason");
            });

            modelBuilder.Entity<RecordPatrol>(entity =>
            {
                entity.ToTable("Record_Patrol");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PatrolName)
                    .HasMaxLength(100)
                    .HasColumnName("Patrol_Name");

                entity.Property(e => e.PatrolNo)
                    .HasMaxLength(100)
                    .HasColumnName("Patrol_NO");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                
                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");
            });

            modelBuilder.Entity<RecordRepair>(entity =>
            {
                entity.ToTable("Record_Repair");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pig_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Repair).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordSale>(entity =>
            {
                entity.ToTable("Record_Sale");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Customer_GUID");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.SalesOrderComment)
                    .HasColumnType("ntext")
                    .HasColumnName("SalesOrder_Comment");

                entity.Property(e => e.SalesOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SalesOrder_Date");

                entity.Property(e => e.SalesOrderName)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_Name");

                entity.Property(e => e.SalesOrderNo)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_NO");

                entity.Property(e => e.SalesOrderTime)
                    .HasMaxLength(10)
                    .HasColumnName("SalesOrder_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UploadDocument)
                   .HasMaxLength(100)
                   .HasColumnName("UploadDocument");
            });

            modelBuilder.Entity<RecordTower>(entity =>
            {
                entity.ToTable("Record_Tower");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RecordVectorControl>(entity =>
            {
                entity.ToTable("Record_VectorControl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyDays).HasMaxLength(10);

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Capacity).HasMaxLength(10);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Frequency).HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.UseUnit).HasMaxLength(10);

                entity.Property(e => e.VectorControlGuid)
                    .HasMaxLength(40)
                    .HasColumnName("VectorControl_GUID");
                
                entity.Property(e => e.InventoryDate)
                   .HasColumnType("datetime")
                   .HasColumnName("Inventory_Date");

                entity.Property(e => e.InventoryReason)
                   .HasMaxLength(100)
                   .HasColumnName("Inventory_Reason");

               entity.Property(e => e.InventoryGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Inventory_GUID");
                
                entity.Property(e => e.AreaGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Area_GUID");
                
                entity.Property(e => e.BarnGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Barn_GUID");
            });

            modelBuilder.Entity<RecordWeighing>(entity =>
            {
                entity.ToTable("Record_Weighing");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Apply_Date");

                entity.Property(e => e.ApplyGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Apply_GUID");

                entity.Property(e => e.ApplyReason)
                    .HasMaxLength(100)
                    .HasColumnName("Apply_Reason");

                entity.Property(e => e.AgreeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agree_Date");

                entity.Property(e => e.AgreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Agree_GUID");

                entity.Property(e => e.AgreeReason)
                    .HasMaxLength(100)
                    .HasColumnName("Agree_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.ExecuteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Execute_Date");

                entity.Property(e => e.ExecuteGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Execute_GUID");

                entity.Property(e => e.ExecuteReason)
                    .HasMaxLength(100)
                    .HasColumnName("Execute_Reason");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrder_GUID");
entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
entity.Property(e => e.UpperRecord)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_Record");

                entity.Property(e => e.NetWeight).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.RecordResult)
                    .HasMaxLength(10)
                    .HasColumnName("Record_Result");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RoomGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Room_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UseType).HasMaxLength(10);

                entity.Property(e => e.Weight).HasColumnType("numeric(18, 3)");
            });

            #endregion

            #region BioS
            modelBuilder.Entity<BioS2pen>(entity =>
            {
                entity.ToTable("BioS_2Pen");

                entity.Property(e => e.BioSMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BioS_Master_GUID");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");
            });

            modelBuilder.Entity<BioS2pig>(entity =>
            {

                entity.ToTable("BioS_2Pig");

                entity.Property(e => e.BioSMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("BioS_Master_GUID");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");
            });

            modelBuilder.Entity<BioSMaster>(entity =>
            {

                entity.ToTable("BioS_Master");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MakeOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("MakeOrderGUID");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });


            #endregion

            #region Pig
            modelBuilder.Entity<Pig>(entity =>
               {
                   entity.ToTable("Pig");

                   entity.Property(e => e.Id)
                       .HasColumnType("numeric(18, 0)")
                       .ValueGeneratedOnAdd()
                       .HasColumnName("ID");

                   entity.Property(e => e.AreaGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Area_GUID");

                   entity.Property(e => e.BarnGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Barn_GUID");

                   entity.Property(e => e.BirthPenGuid)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("BirthPen_GUID");

                   entity.Property(e => e.Birthday).HasColumnType("datetime");

                   entity.Property(e => e.Breed).HasMaxLength(40);

                   entity.Property(e => e.CancelFlag)
                       .HasMaxLength(1)
                       .HasColumnName("CANCEL_FLAG");

                   entity.Property(e => e.Comment)
                       .HasColumnType("ntext")
                       .HasColumnName("COMMENT");

                   entity.Property(e => e.CreateBy)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("CREATE_BY");

                   entity.Property(e => e.CreateDate)
                       .HasColumnType("datetime")
                       .HasColumnName("CREATE_DATE");

                   entity.Property(e => e.CullingTankGuid)
                       .HasMaxLength(40)
                       .HasColumnName("CullingTank_GUID");

                   entity.Property(e => e.DayAge).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.EarNo).HasMaxLength(40);

                   entity.Property(e => e.EarTag).HasMaxLength(40);

                   entity.Property(e => e.EnterDate).HasColumnType("datetime");

                   entity.Property(e => e.EnterDept).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.EnterOrigin).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.FarmGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Farm_GUID");

                   entity.Property(e => e.FarrowComment)
                       .HasColumnType("ntext")
                       .HasColumnName("Farrow_COMMENT");

                   entity.Property(e => e.FarrowStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Farrow_STATUS");

                   entity.Property(e => e.FatherGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Father_GUID");

                   entity.Property(e => e.FinisherCheckInDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Finisher_CheckIN_Date");

                   entity.Property(e => e.FinisherCheckInStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Finisher_CheckIN_STATUS");

                   entity.Property(e => e.FinisherCheckOutDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Finisher_CheckOUT_Date");

                   entity.Property(e => e.FinisherCheckOutStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Finisher_CheckOUT_STATUS");

                   entity.Property(e => e.GrowerCheckInDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Grower_CheckIN_Date");

                   entity.Property(e => e.GrowerCheckInStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Grower_CheckIN_STATUS");

                   entity.Property(e => e.GrowerCheckOutDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Grower_CheckOUT_Date");

                   entity.Property(e => e.GrowerCheckOutStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Grower_CheckOUT_STATUS");

                   entity.Property(e => e.Guid)
                       .HasMaxLength(40)
                       .HasColumnName("GUID")
                       .HasDefaultValueSql("(newid())");

                   entity.Property(e => e.Idno)
                       .HasMaxLength(40)
                       .HasColumnName("IDNo");

                   entity.Property(e => e.MotherGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Mother_GUID");

                   entity.Property(e => e.Outsourcing).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.PenGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Pen_GUID");

                   entity.Property(e => e.Phase).HasMaxLength(10);

                   entity.Property(e => e.PigType)
                       .HasMaxLength(40)
                       .HasColumnName("Pig_Type");

                   entity.Property(e => e.Rfidtag)
                       .HasMaxLength(40)
                       .HasColumnName("RFIDTag");

                   entity.Property(e => e.RoomGuid)
                       .HasMaxLength(40)
                       .HasColumnName("Room_GUID");

                   entity.Property(e => e.Sex).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.Status)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("STATUS");

                   entity.Property(e => e.SuckingCheckInDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Sucking_CheckIN_Date");

                   entity.Property(e => e.SuckingCheckInStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Sucking_CheckIN_STATUS");

                   entity.Property(e => e.SuckingCheckOutDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Sucking_CheckOUT_Date");

                   entity.Property(e => e.SuckingCheckOutStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Sucking_CheckOUT_STATUS");

                   entity.Property(e => e.TransferDate).HasColumnType("datetime");

                   entity.Property(e => e.TransferFrom).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.TransferMoney).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.UpdateBy)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("UPDATE_BY");

                   entity.Property(e => e.UpdateDate)
                       .HasColumnType("datetime")
                       .HasColumnName("UPDATE_DATE");

                   entity.Property(e => e.Weight).HasColumnType("numeric(18, 0)");

                   entity.Property(e => e.WeightDate).HasColumnType("datetime");

                   entity.Property(e => e.WeightDayAge).HasColumnType("numeric(18, 0)");
                   entity.Property(e => e.MakeOrderGuid)
                     .HasMaxLength(40)
                     .HasColumnName("MakeOrder_GUID");

                   entity.Property(e => e.NurseryCheckInDate)
                         .HasColumnType("datetime")
                         .HasColumnName("Nursery_CheckIN_Date");

                   entity.Property(e => e.NurseryCheckInStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Nursery_CheckIN_STATUS");

                   entity.Property(e => e.NurseryCheckOutDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Nursery_CheckOUT_Date");

                   entity.Property(e => e.NurseryCheckOutStatus)
                       .HasColumnType("numeric(18, 0)")
                       .HasColumnName("Nursery_CheckOUT_STATUS");
               });

            modelBuilder.Entity<PigCode>(entity =>
            {
                entity.ToTable("Pig_Code");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EarNo).HasMaxLength(40);

                entity.Property(e => e.EarTag).HasMaxLength(40);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PedigreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pedigree_GUID");




                entity.Property(e => e.Rfid)
                    .HasMaxLength(40)
                    .HasColumnName("RFID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<PigGenetic>(entity =>
            {
                entity.ToTable("Pig_Genetic");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.GeneticAa)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_AA");

                entity.Property(e => e.GeneticCast)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_CAST");

                entity.Property(e => e.GeneticCckar1)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_CCKAR1");

                entity.Property(e => e.GeneticCckar2)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_CCKAR2");

                entity.Property(e => e.GeneticCckar3)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_CCKAR3");

                entity.Property(e => e.GeneticCckar4)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_CCKAR4");

                entity.Property(e => e.GeneticEpor)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_EPOR");

                entity.Property(e => e.GeneticEsr)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_ESR");

                entity.Property(e => e.GeneticGg)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_GG");

                entity.Property(e => e.GeneticGg2)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_GG2");

                entity.Property(e => e.GeneticHal)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_HAL");

                entity.Property(e => e.GeneticHmga1)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_HMGA1");

                entity.Property(e => e.GeneticHmga2)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_HMGA2");

                entity.Property(e => e.GeneticRn)
                    .HasMaxLength(40)
                    .HasColumnName("Genetic_RN");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PedigreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pedigree_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<PigPedigree>(entity =>
            {
                entity.ToTable("Pig_Pedigree");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");
                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Breed).HasMaxLength(40);

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EarNo).HasMaxLength(40);

                entity.Property(e => e.EarTag).HasMaxLength(40);

                entity.Property(e => e.FatherGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Father_GUID");

                entity.Property(e => e.FromPigFarm)
                    .HasMaxLength(40)
                    .HasColumnName("From_PigFarm");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MotherGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Mother_GUID");

                entity.Property(e => e.PedigreeName)
                    .HasMaxLength(40)
                    .HasColumnName("Pedigree_Name");

                entity.Property(e => e.Rfid)
                    .HasMaxLength(40)
                    .HasColumnName("RFID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<PigTesting>(entity =>
            {
                entity.ToTable("Pig_Testing");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("CANCEL_FLAG");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PedigreeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pedigree_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            #endregion

            modelBuilder.Entity<Acceptance>(entity =>
            {
                entity.ToTable("Acceptance");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AcceptanceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Acceptance_Date");

                entity.Property(e => e.AcceptanceDept)
                    .HasMaxLength(100)
                    .HasColumnName("Acceptance_Dept");

                entity.Property(e => e.AcceptanceReason)
                    .HasMaxLength(100)
                    .HasColumnName("Acceptance_Reason");

                entity.Property(e => e.AcceptanceTime)
                    .HasMaxLength(10)
                    .HasColumnName("Acceptance_TIME");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<AcceptanceCheck>(entity =>
            {
                entity.ToTable("Acceptance_Check");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AcceptanceGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Acceptance_GUID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CheckDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Check_Date");

                entity.Property(e => e.CheckDept)
                    .HasMaxLength(100)
                    .HasColumnName("Check_Dept");

                entity.Property(e => e.CheckReason)
                    .HasMaxLength(100)
                    .HasColumnName("Check_Reason");

                entity.Property(e => e.CheckTime)
                    .HasMaxLength(10)
                    .HasColumnName("Check_TIME");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<AcceptanceCheckIn>(entity =>
            {
                entity.ToTable("Acceptance_CheckIn");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AcceptanceGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Acceptance_GUID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CheckIn_Date");

                entity.Property(e => e.CheckInDept)
                    .HasMaxLength(100)
                    .HasColumnName("CheckIn_Dept");

                entity.Property(e => e.CheckInReason)
                    .HasMaxLength(100)
                    .HasColumnName("CheckIn_Reason");

                entity.Property(e => e.CheckInTime)
                    .HasMaxLength(10)
                    .HasColumnName("CheckIn_TIME");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<AcceptanceInspection>(entity =>
            {
                entity.ToTable("Acceptance_Inspection");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AcceptanceGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Acceptance_GUID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InspectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inspection_Date");

                entity.Property(e => e.InspectionDept)
                    .HasMaxLength(100)
                    .HasColumnName("Inspection_Dept");

                entity.Property(e => e.InspectionReason)
                    .HasMaxLength(100)
                    .HasColumnName("Inspection_Reason");

                entity.Property(e => e.InspectionTime)
                    .HasMaxLength(10)
                    .HasColumnName("Inspection_TIME");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InventoryLocation)
                    .HasMaxLength(100)
                    .HasColumnName("Inventory_Location");

                entity.Property(e => e.InventoryName)
                    .HasMaxLength(100)
                    .HasColumnName("Inventory_Name");

                entity.Property(e => e.InventoryNo)
                    .HasMaxLength(100)
                    .HasColumnName("Inventory_NO");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<InventoryChange>(entity =>
            {
                entity.ToTable("Inventory_Change");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date");

                entity.Property(e => e.ChangeGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Change_GUID");

                entity.Property(e => e.ThingGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Thing_GUID");

                entity.Property(e => e.MaterialGuid)
                  .HasMaxLength(40)
                  .HasColumnName("Material_GUID");

                entity.Property(e => e.ChangeTime)
                    .HasMaxLength(10)
                    .HasColumnName("Change_TIME");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FromInventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("From_Inventory_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToInventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("To_Inventory_GUID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Type)
                    .HasMaxLength(40)
                    .HasColumnName("Type");

                entity.Property(e => e.InventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Inventory_GUID");

                entity.Property(e => e.InventoryType)
                    .HasMaxLength(40)
                    .HasColumnName("Inventory_Type");

                entity.Property(e => e.InventoryAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Inventory_AMOUNT");

                entity.Property(e => e.OriginalAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ORIGINAL_AMOUNT");
            });

            modelBuilder.Entity<InventoryScrap>(entity =>
            {
                entity.ToTable("Inventory_Scrap");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.FromInventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("From_Inventory_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ScrapDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Scrap_Date");

                entity.Property(e => e.ScrapGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Scrap_GUID");

                entity.Property(e => e.ScrapTime)
                    .HasMaxLength(10)
                    .HasColumnName("Scrap_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Type)
                    .HasMaxLength(40)
                    .HasColumnName("Type");

                entity.Property(e => e.InventoryGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Inventory_GUID");

                entity.Property(e => e.InventoryType)
                    .HasMaxLength(40)
                    .HasColumnName("Inventory_Type");

                entity.Property(e => e.InventoryAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Inventory_AMOUNT");

                entity.Property(e => e.OriginalAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ORIGINAL_AMOUNT");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");
                entity.Property(e => e.ExpireDate)
                   .HasColumnType("datetime")
                   .HasColumnName("EXPIRE_DATE");
                entity.Property(e => e.MaterialName)
                                    .HasMaxLength(100)
                                    .HasColumnName("Material_Name");

                entity.Property(e => e.DeleteBy)
                                   .HasColumnType("numeric(18, 0)")
                                   .HasColumnName("DELETE_BY");
                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.MaterialNo)
                    .HasMaxLength(100)
                    .HasColumnName("Material_No");

                entity.Property(e => e.MaterialType)
                    .HasMaxLength(100)
                    .HasColumnName("Material_Type");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Purchase_Date");

                entity.Property(e => e.PurchaseDept)
                    .HasMaxLength(100)
                    .HasColumnName("Purchase_Dept");

                entity.Property(e => e.PurchaseTime)
                    .HasMaxLength(40)
                    .HasColumnName("Purchase_TIME");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");
                entity.Property(e => e.AccountGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Account_GUID");

                entity.Property(e => e.RejectDate)
                  .HasColumnType("datetime")
                  .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");


                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.ToTable("Repair");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RepairComment)
                    .HasColumnType("ntext")
                    .HasColumnName("Repair_Comment");

                entity.Property(e => e.RepairDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Repair_Date");

                entity.Property(e => e.RepairName)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_Name");

                entity.Property(e => e.RepairNo)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_NO");

                entity.Property(e => e.RepairTime)
                    .HasMaxLength(10)
                    .HasColumnName("Repair_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RepairDetail>(entity =>
            {
                entity.ToTable("Repair_Detail");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.RepairGuid)
                  .HasMaxLength(40)
                  .HasColumnName("Repair_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RepairDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Repair_Date");

                entity.Property(e => e.RepairDept)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_Dept");

                entity.Property(e => e.RepairReason)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_Reason");

                entity.Property(e => e.RepairTime)
                    .HasMaxLength(10)
                    .HasColumnName("Repair_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RepairRecord>(entity =>
            {
                entity.ToTable("Repair_Record");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RepairGuid)
                 .HasMaxLength(40)
                 .HasColumnName("Repair_GUID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RepairDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Repair_Date");

                entity.Property(e => e.RepairDept)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_Dept");

                entity.Property(e => e.RepairReason)
                    .HasMaxLength(100)
                    .HasColumnName("Repair_Reason");

                entity.Property(e => e.RepairTime)
                    .HasMaxLength(10)
                    .HasColumnName("Repair_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.ToTable("Requisition");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.RequisitionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Requisition_Date");

                entity.Property(e => e.RequisitionDept)
                    .HasMaxLength(100)
                    .HasColumnName("Requisition_Dept");

                entity.Property(e => e.RequisitionReason)
                    .HasMaxLength(100)
                    .HasColumnName("Requisition_Reason");

                entity.Property(e => e.RequisitionTime)
                    .HasMaxLength(10)
                    .HasColumnName("Requisition_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RequisitionFeed>(entity =>
            {
                entity.ToTable("Requisition_Feed");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RequisitionMaterial>(entity =>
            {
                entity.ToTable("Requisition_Material");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RequisitionMedicine>(entity =>
            {
                entity.ToTable("Requisition_Medicine");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RequisitionThing>(entity =>
            {
                entity.ToTable("Requisition_Things");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RequisitionGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Requisition_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.ToTable("SalesOrder");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Customer_GUID");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.SalesOrderComment)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_Comment");

                entity.Property(e => e.SalesOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SalesOrder_Date");

                entity.Property(e => e.SalesOrderName)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_Name");

                entity.Property(e => e.SalesOrderNo)
                    .HasMaxLength(100)
                    .HasColumnName("SalesOrder_NO");

                entity.Property(e => e.SalesOrderTime)
                    .HasMaxLength(10)
                    .HasColumnName("SalesOrder_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<SalesOrderCheckOut>(entity =>
            {
                entity.ToTable("SalesOrder_CheckOut");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.SalesOrderGuid)
                  .HasMaxLength(40)
                  .HasColumnName("SalesOrder_GUID");

                entity.Property(e => e.AccountGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Account_GUID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CheckOut_Date");

                entity.Property(e => e.CheckOutTime)
                    .HasMaxLength(10)
                    .HasColumnName("CheckOut_TIME");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.CheckOutComment)
                    .HasMaxLength(100)
                    .HasColumnName("CheckOut_Comment");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.ToTable("SalesOrder_Detail");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SalesOrderGuid)
                    .HasMaxLength(40)
                    .HasColumnName("SalesOrder_GUID");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Thing>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");
                entity.Property(e => e.ThingName)
                    .HasMaxLength(100)
                    .HasColumnName("Thing_Name");

                entity.Property(e => e.ThingNo)
                    .HasMaxLength(100)
                    .HasColumnName("Thing_No");

                entity.Property(e => e.ThingType)
                    .HasMaxLength(100)
                    .HasColumnName("Thing_Type");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CancelFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_FLAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Contact_EMAIL");

                entity.Property(e => e.ContactMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_MOBILE");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.ContactTel)
                    .HasMaxLength(20)
                    .HasColumnName("Contact_TEL");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(20)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Vendor_ADDRESS");

                entity.Property(e => e.VendorBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("Vendor_BIRTHDAY");

                entity.Property(e => e.VendorEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Vendor_EMAIL");

                entity.Property(e => e.VendorIdcard)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor_IDCARD");

                entity.Property(e => e.VendorMobile)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor_MOBILE");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor_NAME");

                entity.Property(e => e.VendorNickname)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor_NICKNAME");

                entity.Property(e => e.VendorNo)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_NO");

                entity.Property(e => e.VendorSex)
                    .HasMaxLength(1)
                    .HasColumnName("Vendor_SEX");

                entity.Property(e => e.VendorTel)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor_TEL");
            });

            modelBuilder.Entity<ReportConfig>(entity =>
            {
                entity.ToTable("Report_Config");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.Slcn)
                    .HasMaxLength(500)
                    .HasColumnName("SLCN");

                entity.Property(e => e.Slen)
                    .HasMaxLength(500)
                    .HasColumnName("SLEN");

                entity.Property(e => e.Slkey)
                    .HasMaxLength(50)
                    .HasColumnName("SLKey");

                entity.Property(e => e.Slpage)
                    .HasMaxLength(50)
                    .HasColumnName("SLPage");

                entity.Property(e => e.Sltw)
                    .HasMaxLength(500)
                    .HasColumnName("SLTW");

                entity.Property(e => e.Sltype)
                    .HasMaxLength(50)
                    .HasColumnName("SLType");

                entity.Property(e => e.Slvn)
                    .HasMaxLength(500)
                    .HasColumnName("SLVN");

                entity.Property(e => e.Sequence)
                   .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Sequence");

                entity.Property(e => e.ColumnWidth)
                   .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ColumnWidth");

                entity.Property(e => e.SystemMenuGuid)
                 .HasMaxLength(40)
                 .HasColumnName("SystemMenuGuid");


            });

            modelBuilder.Entity<PigDisease>(entity =>
            {


                entity.ToTable("Pig_Disease");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Approve_Date");

                entity.Property(e => e.ApproveGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Approve_GUID");

                entity.Property(e => e.ApproveReason)
                    .HasMaxLength(100)
                    .HasColumnName("Approve_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.RecordReason)
                    .HasMaxLength(100)
                    .HasColumnName("Record_Reason");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<PigCulling>(entity =>
            {


                entity.ToTable("Pig_Culling");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Culling).HasMaxLength(100);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigDiagnosis>(entity =>
            {


                entity.ToTable("Pig_Diagnosis");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Diagnosis).HasMaxLength(100);

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigDisease2pen>(entity =>
            {


                entity.ToTable("Pig_Disease_2Pen");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.PigDiseaseMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pig_Disease_Master_GUID");
            });

            modelBuilder.Entity<PigDisease2pig>(entity =>
            {


                entity.ToTable("Pig_Disease_2Pig");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigDiseaseMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Pig_Disease_Master_GUID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");
            });

            modelBuilder.Entity<PigFarmVector>(entity =>
            {


                entity.ToTable("PigFarm_Vector");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Approve_Date");

                entity.Property(e => e.ApproveGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Approve_GUID");

                entity.Property(e => e.ApproveReason)
                    .HasMaxLength(100)
                    .HasColumnName("Approve_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.RecordReason)
                    .HasMaxLength(100)
                    .HasColumnName("Record_Reason");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });
            modelBuilder.Entity<PigFarmVector2pen>(entity =>
            {


                entity.ToTable("PigFarm_Vector_2Pen");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.PigFarmVectorMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PigFarm_Vector_Master_GUID");
            });

            modelBuilder.Entity<PigFarmVector2pig>(entity =>
            {


                entity.ToTable("PigFarm_Vector_2Pig");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");

                entity.Property(e => e.PigFarmVectorMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PigFarm_Vector_Master_GUID");
            });

            modelBuilder.Entity<PigFarmVectorPlan>(entity =>
            {
                entity.ToTable("PigFarm_VectorPlan");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.VectorPlan)
                   .HasMaxLength(100)
                   .HasColumnName("VectorPlan");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigFarmVectorRecord>(entity =>
            {


                entity.ToTable("PigFarm_VectorRecord");

                entity.Property(e => e.VectorRecord).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigFarmVectorSchedule>(entity =>
            {


                entity.ToTable("PigFarm_VectorSchedule");

                entity.Property(e => e.VectorSchedule).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigHouseCleaning>(entity =>
            {


                entity.ToTable("PigHouse_Cleaning");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Approve_Date");

                entity.Property(e => e.ApproveGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Approve_GUID");

                entity.Property(e => e.ApproveReason)
                    .HasMaxLength(100)
                    .HasColumnName("Approve_Reason");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigType)
                    .HasMaxLength(100)
                    .HasColumnName("Pig_Type");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Record_GUID");

                entity.Property(e => e.RecordReason)
                    .HasMaxLength(100)
                    .HasColumnName("Record_Reason");

                entity.Property(e => e.RejectDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reject_Date");

                entity.Property(e => e.RejectGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Reject_GUID");

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(100)
                    .HasColumnName("Reject_Reason");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<PigHouseCleaning2pen>(entity =>
            {


                entity.ToTable("PigHouse_Cleaning_2Pen");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PenGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PEN_GUID");

                entity.Property(e => e.PigHouseCleaningMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PigHouse_Cleaning_Master_GUID");
            });

            modelBuilder.Entity<PigHouseCleaning2pig>(entity =>
            {


                entity.ToTable("PigHouse_Cleaning_2Pig");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PigGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PIG_GUID");

                entity.Property(e => e.PigHouseCleaningMasterGuid)
                    .HasMaxLength(40)
                    .HasColumnName("PigHouse_Cleaning_Master_GUID");
            });

            modelBuilder.Entity<PigHouseCleaningPlan>(entity =>
            {


                entity.ToTable("PigHouse_CleaningPlan");

                entity.Property(e => e.CleaningPlan).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigHouseCleaningRecord>(entity =>
            {


                entity.ToTable("PigHouse_CleaningRecord");

                entity.Property(e => e.CleaningRecord).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigHouseCleaningSchedule>(entity =>
            {


                entity.ToTable("PigHouse_CleaningSchedule");

                entity.Property(e => e.CleaningSchedule).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });



            modelBuilder.Entity<PigIsolation>(entity =>
            {


                entity.ToTable("Pig_Isolation");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Isolation).HasMaxLength(100);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigPrescription>(entity =>
            {


                entity.ToTable("Pig_Prescription");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Prescription).HasMaxLength(100);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");
            });

            modelBuilder.Entity<PigTreatment>(entity =>
            {


                entity.ToTable("Pig_Treatment");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.RecordTime)
                    .HasMaxLength(5)
                    .HasColumnName("Record_TIME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Treatment).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpperGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Upper_GUID");

                entity.Property(e => e.EstDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_Date");

                entity.Property(e => e.EstTime)
                    .HasMaxLength(5)
                    .HasColumnName("EST_TIME");

                entity.Property(e => e.PigGuid)
             .HasMaxLength(40)
             .HasColumnName("Pig_GUID");

                entity.Property(e => e.PenGuid)
                   .HasMaxLength(40)
                   .HasColumnName("Pen_GUID");
                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.MakeOrderGuid)
                 .HasMaxLength(40)
                 .HasColumnName("MakeOrder_GUID");
                entity.Property(e => e.CullingPenGuid)
                      .HasMaxLength(40)
                      .HasColumnName("Culling_Pen_GUID");
            });

            modelBuilder.Entity<StoredProcedure>(entity =>
            {
                entity.ToTable("StoredProcedures");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.StoredName)
                    .HasMaxLength(100)
                    .HasColumnName("Stored_Name");
                entity.Property(e => e.Legend)
                 .HasMaxLength(200);

                entity.Property(e => e.StoredType)
                   .HasMaxLength(20)
                   .HasColumnName("Stored_Type");
                entity.Property(e => e.Color)
                 .HasMaxLength(20)
                 .HasColumnName("Color");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.SystemMenuGuid)
                    .HasMaxLength(40)
                    .HasColumnName("SystemMenuGuid");
            });
            modelBuilder.Entity<Rfid>(entity =>
            {
                entity.ToTable("RFID");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RfidName)
                    .HasMaxLength(100)
                    .HasColumnName("RFID_Name");

                entity.Property(e => e.RfidNo)
                    .HasMaxLength(100)
                    .HasColumnName("RFID_No");

                entity.Property(e => e.RfidType)
                    .HasMaxLength(100)
                    .HasColumnName("RFID_Type");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");
            });

            modelBuilder.Entity<Semen>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SemenName)
                    .HasMaxLength(100)
                    .HasColumnName("Semen_Name");

                entity.Property(e => e.SemenNo)
                    .HasMaxLength(100)
                    .HasColumnName("Semen_No");

                entity.Property(e => e.SemenType)
                    .HasMaxLength(100)
                    .HasColumnName("Semen_Type");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");
            });

            modelBuilder.Entity<SemenMix>(entity =>
            {
                entity.ToTable("SemenMix");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeleteBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DELETE_BY");

                entity.Property(e => e.DeleteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETE_DATE");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.FarmGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Farm_GUID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(40)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SemenMixName)
                    .HasMaxLength(100)
                    .HasColumnName("SemenMix_Name");

                entity.Property(e => e.SemenMixNo)
                    .HasMaxLength(100)
                    .HasColumnName("SemenMix_No");

                entity.Property(e => e.SemenMixType)
                    .HasMaxLength(100)
                    .HasColumnName("SemenMix_Type");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("SPEC");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorGuid)
                    .HasMaxLength(40)
                    .HasColumnName("Vendor_GUID");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //Tự động cập nhật ngày giờ thêm mới và chỉnh sửa
            AutoAddDateTracking();
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging().EnableDetailedErrors();
#endif
        public void AutoAddDateTracking()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        SetValueProperty(ref changedOrAddedItem, "CreateDate", "CreateBy");
                    }
                    if (item.State == EntityState.Modified)
                    {
                        SetValueProperty(ref changedOrAddedItem, "UpdateDate", "UpdateBy");
                        SetDeleteValueProperty(ref changedOrAddedItem);


                    }
                }
            }
        }
        public decimal? GetPropValue(object src, string propName)
        {
            return (decimal?)src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public void SetDeleteValueProperty(ref object changedOrAddedItem)
        {
            string deleteDate = "DeleteDate";
            string status = "Status";
            string deleteBy = "DeleteBy";
            Type type = changedOrAddedItem.GetType();
            PropertyInfo propAdd = type.GetProperty(deleteDate);
            PropertyInfo propStatus = type.GetProperty(status);


            if (propStatus != null && propStatus.PropertyType.Name == "Decimal")
            {
                var statusValue = (decimal?)propStatus.GetValue(changedOrAddedItem, null);
                if (statusValue == 0)
                {
                    if (propAdd != null)
                    {
                        propAdd.SetValue(changedOrAddedItem, DateTime.Now, null);
                    }
                    var httpContext = _contextAccessor.HttpContext;
                    if (httpContext != null)
                    {
                        var accessToken = httpContext.Request.Headers["Authorization"];
                        var accountID = JWTExtensions.GetDecodeTokenByID(accessToken).ToDecimal();
                        PropertyInfo propCreateBy = type.GetProperty(deleteBy);
                        if (propCreateBy != null)
                        {
                            if (accountID > 0)
                            {
                                propCreateBy.SetValue(changedOrAddedItem, accountID, null);
                            }
                        }
                    }
                }

            }

        }
        public void SetValueProperty(ref object changedOrAddedItem, string propDate, string propUser)
        {
            Type type = changedOrAddedItem.GetType();
            PropertyInfo propAdd = type.GetProperty(propDate);
            if (propAdd != null)
            {
                propAdd.SetValue(changedOrAddedItem, DateTime.Now, null);
            }
            var httpContext = _contextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = httpContext.Request.Headers["Authorization"];
                var accountID = JWTExtensions.GetDecodeTokenByID(accessToken).ToDecimal();
                PropertyInfo propCreateBy = type.GetProperty(propUser);
                if (propCreateBy != null)
                {
                    if (accountID > 0)
                    {
                        propCreateBy.SetValue(changedOrAddedItem, accountID, null);
                    }
                }
            }
        }
    }
}
