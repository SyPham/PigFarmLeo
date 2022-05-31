using AutoMapper;
using PigFarm.DTO;
using PigFarm.DTO.auth;
using PigFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PigFarm.Helpers.AutoMapper
{
    public class DtoToEFMappingProfile : Profile
    {
        public DtoToEFMappingProfile()
        {
            CreateMap<AccountDto, Account>()
                .ForMember(d => d.AccountType, o => o.Ignore());
            CreateMap<AccountTypeDto, AccountType>()
                .ForMember(d => d.Accounts, o => o.Ignore());
            CreateMap<PlanDto, Plan>();
            CreateMap<MailingDto, Mailing>();
            CreateMap<ToDoListDto, ToDoList>();
            CreateMap<UserForDetailDto, Account>();
            CreateMap<OCDto, Oc>();

            CreateMap<FeedDto, Feed>();
            CreateMap<FeedCategory, FeedCategory>();
            CreateMap<PigDto, Pig>();
            CreateMap<PigKindDto, PigKind>();
            CreateMap<MedicineDto, Medicine>();
            CreateMap<OCDto, Oc>();
            CreateMap<AccountRoleDto, AccountRole>();
            CreateMap<AccountPermissionDto, AccountPermission>();
            CreateMap<AccountGroupDto, AccountGroup>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<FoodDto, Food>();
            CreateMap<FeedingDto, Feeding>();
            CreateMap<DailyFeedingDto, DailyFeeding>();
            CreateMap<BomDto, Bom>();

            CreateMap<EmployeeDto, Employee>();
            CreateMap<MethodDto, Method>();
            CreateMap<VaccineDto, Vaccine>();
            CreateMap<SystemLanguageDto, SystemLanguage>();
            CreateMap<FunctionDto, FunctionSystem>();
            CreateMap<ModuleDto, Module>();

            CreateMap<BomMoveDto, BomMove>();
            CreateMap<BomFeedDto, BomFeed>();
            CreateMap<BomImmunizationDto, BomImmunization>();
            CreateMap<BomTreatmentDto, BomTreatment>();
            CreateMap<BomDisinfectionDto, BomDisinfection>();
            CreateMap<BomVectorControlDto, BomVectorControl>();

            CreateMap<FarmDto, Farm>();
            CreateMap<AreaDto, Area>();
            CreateMap<BarnDto, Barn>();
            CreateMap<RoleDto, Role>();
            CreateMap<PenDto, Pen>();
            CreateMap<RoomDto, Room>();
            CreateMap<CullingTankDto, CullingTank>();

            CreateMap<XAccountDto, XAccount>();
            CreateMap<XAccountGroupDto, XAccountGroup>();
            CreateMap<SysMenuDto, SysMenu>();

            CreateMap<RecordCullingDto, RecordCulling>();
            CreateMap<RecordDeathDto, RecordDeath>();
            CreateMap<RecordDiagnosisDto, RecordDiagnosis>();
            CreateMap<RecordDisinfectionDto, RecordDisinfection>();
            CreateMap<RecordDonateDto, RecordDonate>();
            CreateMap<RecordEarTagDto, RecordEarTag>();
            CreateMap<RecordFeedingDto, RecordFeeding>();
            CreateMap<RecordGeneralDto, RecordGeneral>();
            CreateMap<RecordImmunizationDto, RecordImmunization>();
            CreateMap<RecordInOutDto, RecordInOut>();
            CreateMap<RecordInOut2PigDto, RecordInOut2Pig>();
            CreateMap<RecordInventoryCheckDto, RecordInventoryCheck>();
            CreateMap<RecordMoveDto, RecordMove>();
            CreateMap<RecordPatrolDto, RecordPatrol>();
            CreateMap<RecordRepairDto, RecordRepair>();
            CreateMap<RecordSaleDto, RecordSale>();
            CreateMap<RecordTowerDto, RecordTower>();
            CreateMap<RecordVectorControlDto, RecordVectorControl>();
            CreateMap<RecordWeighingDto, RecordWeighing>();
            CreateMap<RecordCullingSaleDto, RecordCullingSale>(); //

            CreateMap<RecordSiloDto, RecordSilo>();
            CreateMap<RecordChemicalDto, RecordChemical>();
            CreateMap<RecordBuriedDto, RecordBuried>();
            CreateMap<RecordPigInDto, RecordPigIn>();
            CreateMap<RecordPigOutDto, RecordPigOut>();
            CreateMap<RecordKillDto, RecordKill>();
            CreateMap<RecordStolenDto, RecordStolen>();
            CreateMap<Record2PigDto, Record2Pig>();


            CreateMap<MakeOrderDto, MakeOrder>();
            CreateMap<BioSMasterDto, BioSMaster>();
            CreateMap<BioS2penDto, BioS2pen>();
            CreateMap<BioS2pigDto, BioS2pig>();
            CreateMap<BioSRecordDto, BioSRecord>();

            CreateMap<PigCodeDto, PigCode>();
            CreateMap<PigGeneticDto, PigGenetic>();
            CreateMap<PigTestingDto, PigTesting>();
            CreateMap<PigPedigreeDto, PigPedigree>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<Disease, DiseaseDto>();
            CreateMap<Disinfection, DisinfectionDto>();
            CreateMap<Medicine, MedicineDto>();
            CreateMap<Nutrition, NutritionDto>();
            CreateMap<Feed, FeedDto>();
            CreateMap<FeedMaterial, FeedMaterialDto>();
            CreateMap<CodePermission, CodePermissionDto>();


            CreateMap<Acceptance, AcceptanceDto>();
            CreateMap<AcceptanceCheck, AcceptanceCheckDto>();
            CreateMap<AcceptanceCheckIn, AcceptanceCheckInDto>();
            CreateMap<AcceptanceInspection, AcceptanceInspectionDto>();
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryChange, InventoryChangeDto>();
            CreateMap<InventoryScrap, InventoryScrapDto>();
            CreateMap<Material, MaterialDto>();
            CreateMap<Purchase, PurchaseDto>();
            CreateMap<Repair, RepairDto>();
            CreateMap<RepairDetail, RepairDetailDto>();
            CreateMap<RepairRecord, RepairRecordDto>();
            CreateMap<Requisition, RequisitionDto>();
            CreateMap<RequisitionFeed, RequisitionFeedDto>();
            CreateMap<RequisitionMaterial, RequisitionMaterialDto>();
            CreateMap<RequisitionMedicine, RequisitionMedicineDto>();
            CreateMap<RequisitionThing, RequisitionThingDto>();
            CreateMap<SalesOrder, SalesOrderDto>();
            CreateMap<SalesOrderCheckOut, SalesOrderCheckOutDto>();
            CreateMap<SalesOrderDetail, SalesOrderDetailDto>();
            CreateMap<Thing, ThingDto>();
            CreateMap<Vendor, VendorDto>();
            CreateMap<ReportConfig, ReportConfigDto>();


            CreateMap<PigDisease, PigDiseaseDto>();
            CreateMap<PigCulling, PigCullingDto>();
            CreateMap<PigDiagnosis, PigDiagnosisDto>();
            CreateMap<PigDisease2pen, PigDisease2penDto>();
            CreateMap<PigDisease2pig, PigDisease2pigDto>();
            CreateMap<PigFarmVector, PigFarmVectorDto>();
            CreateMap<PigHouseCleaning, PigHouseCleaningDto>();
            CreateMap<PigHouseCleaning2pen, PigHouseCleaning2penDto>();
            CreateMap<PigHouseCleaning2pig, PigHouseCleaning2pigDto>();
            CreateMap<PigHouseCleaningPlan, PigHouseCleaningPlanDto>();
            CreateMap<PigHouseCleaningRecord, PigHouseCleaningRecordDto>();
            CreateMap<PigHouseCleaningSchedule, PigHouseCleaningScheduleDto>();
            CreateMap<PigFarmVector2pen, PigFarmVector2penDto>();
            CreateMap<PigFarmVector2pig, PigFarmVector2pigDto>();
            CreateMap<PigFarmVectorPlan, PigFarmVectorPlanDto>();
            CreateMap<PigFarmVectorRecord, PigFarmVectorRecordDto>();
            CreateMap<PigFarmVectorSchedule, PigFarmVectorScheduleDto>();

            CreateMap<PigIsolation, PigIsolationDto>();
            CreateMap<PigPrescription, PigPrescriptionDto>();
            CreateMap<PigTreatment, PigTreatmentDto>();
            CreateMap<StoredProcedure, StoredProcedureDto>();
            CreateMap<SysMenu, ChartSettingDto>();
            CreateMap<CodeType, CodeTypeDto>();
            CreateMap<VectorControl, VectorControlDto>();
            CreateMap<Dashboard, DashboardDto>();
            CreateMap<RecordImmunization, RecordImmunizationDto>();
            CreateMap<PigFarmVectorControl, PigFarmVectorControlDto>();
            CreateMap<PigHouseDisinfection, PigHouseDisinfectionDto>();
            CreateMap<BomWeighing, BomWeighingDto>();
            CreateMap<BomFeeding, BomFeedingDto>();
            CreateMap<Rfid, RfidDto>();
            CreateMap<Semen, SemenDto>();
            CreateMap<SemenMix, SemenMixDto>();
           
            CreateMap<SystemConfig, SystemConfigDto>();


        }
    }
}
