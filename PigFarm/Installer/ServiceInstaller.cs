using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PigFarm.Helpers;
using PigFarm.Services;

namespace PigFarm.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IToDoListService, ToDoListService>();
            services.AddScoped<IFeedCategoryService, FeedCategoryService>();
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<IOCService, OCService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<ISequenceService, SequenceService>();
            services.AddScoped<IAccountGroupService, AccountGroupService>();
            services.AddScoped<IAccountPermissionService, AccountPermissionService>();
            services.AddScoped<IAccountRoleService, AccountRoleService>();
            services.AddScoped<IEmployeeService, EmployeeService>();


            services.AddScoped<IBomService, BomService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFeedingService, FeedingService>();
            services.AddScoped<IDailyFeedingService, DailyFeedingService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IVaccineService, VaccineService>();
            services.AddScoped<ISystemLanguageService, SystemLanguageService>();
            services.AddScoped<IPermissionService, PermissionService>();


            services.AddScoped<IBomMoveService, BomMoveService>();
            services.AddScoped<IBomFeedService, BomFeedService>();
            services.AddScoped<IBomImmunizationService, BomImmunizationService>();
            services.AddScoped<IBomTreatmentService, BomTreatmentService>();
            services.AddScoped<IBomDisinfectionService, BomDisinfectionService>();
            services.AddScoped<IBomVectorControlService, BomVectorControlService>();

            services.AddScoped<IFarmService, FarmService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IBarnService, BarnService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IPenService, PenService>();
            services.AddScoped<ICullingTankService, CullingTankService>();

            services.AddScoped<IXAccountService, XAccountService>();
            services.AddScoped<IXAccountGroupService, XAccountGroupService>();
            services.AddScoped<ISysMenuService, SysMenuService>();

            services.AddScoped<IRecordCullingService, RecordCullingService>(); 
            services.AddScoped<IRecordCullingSaleService, RecordCullingSaleService>();
            services.AddScoped<IRecordDeathService, RecordDeathService>();
            services.AddScoped<IRecordDiagnosisService, RecordDiagnosisService>();
            services.AddScoped<IRecordDisinfectionService, RecordDisinfectionService>();
            services.AddScoped<IRecordDonateService, RecordDonateService>();
            services.AddScoped<IRecordEarTagService, RecordEarTagService>();
            services.AddScoped<IRecordFeedingService, RecordFeedingService>();
            services.AddScoped<IRecordGeneralService, RecordGeneralService>();
            services.AddScoped<IRecordImmunizationService, RecordImmunizationService>();
            services.AddScoped<IRecordInOutService, RecordInOutService>();
            services.AddScoped<IRecordInventoryCheckService, RecordInventoryCheckService>();
            services.AddScoped<IRecordMoveService, RecordMoveService>();
            services.AddScoped<IRecordPatrolService, RecordPatrolService>();
            services.AddScoped<IRecordRepairService, RecordRepairService>();
            services.AddScoped<IRecordSaleService, RecordSaleService>();
            services.AddScoped<IRecordTowerService, RecordTowerService>();
            services.AddScoped<IRecordVectorControlService, RecordVectorControlService>();
            services.AddScoped<IRecordWeighingService, RecordWeighingService>();

            services.AddScoped<IRecordKillService, RecordKillService>();
            services.AddScoped<IRecordSiloService, RecordSiloService>();
            services.AddScoped<IRecordChemicalService, RecordChemicalService>();
            services.AddScoped<IRecordBuriedService, RecordBuriedService>();
            services.AddScoped<IRecordStolenService, RecordStolenService>();
            services.AddScoped<IRecordPigInService, RecordPigInService>();
            services.AddScoped<IRecordPigOutService, RecordPigOutService>();


            services.AddScoped<IMakeOrderService, MakeOrderService>();
            services.AddScoped<ILineService, LineService>();

            services.AddScoped<IBioS2penService, BioS2penService>();
            services.AddScoped<IBioS2pigService, BioS2pigService>();
            services.AddScoped<IBioSRecordService, BioSRecordService>();
            services.AddScoped<IBioSMasterService, BioSMasterService>();

            services.AddScoped<IPigService, PigService>();
            services.AddScoped<IPigKindService, PigKindService>();
            services.AddScoped<IPigCodeService , PigCodeService>();
            services.AddScoped<IPigGeneticService , PigGeneticService>();
            services.AddScoped<IPigPedigreeService , PigPedigreeService> ();
            services.AddScoped<IPigTestingService ,PigTestingService> ();
            services.AddScoped<IReportService, ReportService> ();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiseaseService, DiseaseService>();
            services.AddScoped<IDisinfectionService, DisinfectionService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<INutritionService, NutritionService>();
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<IFeedMaterialService, FeedMaterialService>();
            services.AddScoped<ICodePermissionService, CodePermissionService>();

            services.AddScoped<IAcceptanceService, AcceptanceService>();
            services.AddScoped<IAcceptanceCheckService, AcceptanceCheckService>();
            services.AddScoped<IAcceptanceCheckInService, AcceptanceCheckInService>();
            services.AddScoped<IAcceptanceInspectionService, AcceptanceInspectionService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryChangeService, InventoryChangeService>();
            services.AddScoped<IInventoryScrapService, InventoryScrapService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IRepairService, RepairService>();
            services.AddScoped<IRepairDetailService, RepairDetailService>();
            services.AddScoped<IRepairRecordService, RepairRecordService>();
            services.AddScoped<IRequisitionService, RequisitionService>();
            services.AddScoped<IRequisitionFeedService, RequisitionFeedService>();
            services.AddScoped<IRequisitionMaterialService, RequisitionMaterialService>();
            services.AddScoped<IRequisitionMedicineService, RequisitionMedicineService>();
            services.AddScoped<IRequisitionThingService, RequisitionThingService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ISalesOrderCheckOutService, SalesOrderCheckOutService>();
            services.AddScoped<ISalesOrderDetailService, SalesOrderDetailService>();
            services.AddScoped<IThingService, ThingService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IReportConfigService, ReportConfigService>();

            services.AddScoped<IPigDiseaseService, PigDiseaseService>();
            services.AddScoped<IPigCullingService, PigCullingService>();
            services.AddScoped<IPigDiagnosisService, PigDiagnosisService>();
            services.AddScoped<IPigDisease2penService, PigDisease2penService>();
            services.AddScoped<IPigDisease2pigService, PigDisease2pigService>();
            services.AddScoped<IPigFarmVectorService, PigFarmVectorService>();
            services.AddScoped<IPigFarmVectorPlanService, PigFarmVectorPlanService>();
            services.AddScoped<IPigFarmVectorRecordService, PigFarmVectorRecordService>();
            services.AddScoped<IPigFarmVectorScheduleService, PigFarmVectorScheduleService>();

            services.AddScoped<IPigHouseCleaningService, PigHouseCleaningService>();
            services.AddScoped<IPigHouseCleaning2penService, PigHouseCleaning2penService>();
            services.AddScoped<IPigHouseCleaning2pigService, PigHouseCleaning2pigService>();
            services.AddScoped<IPigHouseCleaningPlanService, PigHouseCleaningPlanService>();
            services.AddScoped<IPigHouseCleaningRecordService, PigHouseCleaningRecordService>();
            services.AddScoped<IPigHouseCleaningScheduleService, PigHouseCleaningScheduleService>();
            services.AddScoped<IPigHouseVector2penService, PigFarmVector2penService>();
            services.AddScoped<IPigHouseVector2pigService, PigFarmVector2pigService>();
            services.AddScoped<IPigIsolationService, PigIsolationService>();
            services.AddScoped<IPigPrescriptionService, PigPrescriptionService>();
            services.AddScoped<IPigTreatmentService, PigTreatmentService>();
            services.AddScoped<IStoredProcedureService, StoredProcedureService>();
            services.AddScoped<ICodeTypeService, CodeTypeService>();
            services.AddScoped<IVectorControlService, VectorControlService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IRecordImmunizationService, RecordImmunizationService>();
            services.AddScoped<IPigFarmVectorControlService, PigFarmVectorControlService>();
            services.AddScoped<IPigHouseDisinfectionService, PigHouseDisinfectionService>();
            services.AddScoped<IBomWeighingService, BomWeighingService>();
            services.AddScoped<ISemenMixService, SemenMixService>();
            services.AddScoped<ISemenService, SemenService>();
            services.AddScoped<IRfidService, RfidService>();
            services.AddScoped<ISystemConfigService, SystemConfigService>();
            services.AddScoped<IRecord2PigService, Record2PigService>();
        }
    }
}
