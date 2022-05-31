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
    public class EFToDtoMappingProfile : Profile
    {
        public EFToDtoMappingProfile()
        {
            var list = new List<int> { };
            CreateMap<Account, AccountDto>();
            CreateMap<AccountType, AccountTypeDto>();
            CreateMap<Plan, PlanDto>();
            CreateMap<Mailing, MailingDto>();
            CreateMap<ToDoList, ToDoListDto>();
            CreateMap<XAccount, UserForDetailDto>()
                .ForMember(d => d.Username, o => o.MapFrom(x => x.Uid))
                .ForMember(d => d.ID, o => o.MapFrom(x => x.AccountId));

            CreateMap<Feed, FeedDto>();
            CreateMap<FeedCategory, FeedCategoryDto>();
            CreateMap<Pig, PigDto>();
            CreateMap<PigKind, PigKindDto>();
            CreateMap<Medicine, MedicineDto>();
            CreateMap<Oc, OCDto>();
            CreateMap<AccountRole, AccountRoleDto>();
            CreateMap<AccountPermission, AccountPermissionDto>();
            CreateMap<AccountGroup, AccountGroupDto>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Food, FoodDto>();
            CreateMap<Feeding, FeedingDto>();
            CreateMap<DailyFeeding, DailyFeedingDto>().ForMember(d => d.Food, o => o.MapFrom(x => x.Food.Name));
            CreateMap<Bom, BomDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Method, MethodDto>();
            CreateMap<Vaccine, VaccineDto>();
            CreateMap<SystemLanguage, SystemLanguageDto>();
            CreateMap<FunctionSystem, FunctionDto>();
            CreateMap<Module, ModuleDto>();

            CreateMap<BomMove, BomMoveDto>();
            CreateMap<BomFeed, BomFeedDto>();
            CreateMap<BomImmunization, BomImmunizationDto>();
            CreateMap<BomTreatment, BomTreatmentDto>();
            CreateMap<BomDisinfection, BomDisinfectionDto>();
            CreateMap<BomVectorControl, BomVectorControlDto>();

            CreateMap<Farm, FarmDto>();
            CreateMap<Area, AreaDto>();
            CreateMap<Barn, BarnDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Pen, PenDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<CullingTank, CullingTankDto>();
            CreateMap<XAccount, XAccountDto>();
            CreateMap<XAccountGroup, XAccountGroupDto>();
            CreateMap<SysMenu, SysMenuDto>();

            CreateMap<RecordCulling, RecordCullingDto>(); //
            CreateMap<RecordDeath, RecordDeathDto>();//
            CreateMap<RecordDiagnosis, RecordDiagnosisDto>();//
            CreateMap<RecordDisinfection, RecordDisinfectionDto>();//
            CreateMap<RecordDonate, RecordDonateDto>();//
            CreateMap<RecordEarTag, RecordEarTagDto>();//
            CreateMap<RecordFeeding, RecordFeedingDto>();//
            CreateMap<RecordGeneral, RecordGeneralDto>();//
            CreateMap<RecordImmunization, RecordImmunizationDto>();//
            CreateMap<RecordInOut, RecordInOutDto>();//
            CreateMap<RecordInOut2Pig, RecordInOut2PigDto>();//
            CreateMap<RecordInventoryCheck, RecordInventoryCheckDto>();//
            CreateMap<RecordMove, RecordMoveDto>();//
            CreateMap<RecordPatrol, RecordPatrolDto>();//
            CreateMap<RecordRepair, RecordRepairDto>();//
            CreateMap<RecordSale, RecordSaleDto>(); //
            CreateMap<RecordTower, RecordTowerDto>(); //
            CreateMap<RecordVectorControl, RecordVectorControlDto>();
            CreateMap<RecordWeighing, RecordWeighingDto>();//
            CreateMap<RecordCullingSale, RecordCullingSaleDto>(); //

            CreateMap<RecordSilo, RecordSiloDto>();
            CreateMap < RecordChemical, RecordChemicalDto>();
            CreateMap<RecordBuried, RecordBuriedDto>();
            CreateMap<RecordPigIn, RecordPigInDto>();
            CreateMap<RecordPigOut, RecordPigOutDto>();
            CreateMap<RecordKill, RecordKillDto>();
            CreateMap<RecordStolen, RecordStolenDto>();
            CreateMap<Record2Pig, Record2PigDto>();

            CreateMap<MakeOrder, MakeOrderDto>();

            CreateMap<BioSMaster, BioSMasterDto>();
            CreateMap<BioS2pen, BioS2penDto>();
            CreateMap<BioS2pig, BioS2pigDto>();
            CreateMap<BioSRecord, BioSRecordDto>();

            CreateMap<PigCode, PigCodeDto>();
            CreateMap<PigGenetic, PigGeneticDto>();
            CreateMap<PigTesting, PigTestingDto>();
            CreateMap<PigPedigree, PigPedigreeDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<DiseaseDto, Disease>();
            CreateMap<DisinfectionDto, Disinfection>();
            CreateMap<MedicineDto, Medicine>();
            CreateMap<NutritionDto, Nutrition>();
            CreateMap<FeedDto, Feed>();
            CreateMap<FeedMaterialDto, FeedMaterial>();
            CreateMap<CodePermissionDto, CodePermission>();

            CreateMap<AcceptanceDto, Acceptance>();
            CreateMap<AcceptanceCheckDto, AcceptanceCheck>();
            CreateMap<AcceptanceCheckInDto, AcceptanceCheckIn>();
            CreateMap<AcceptanceInspectionDto, AcceptanceInspection>();
            CreateMap<InventoryDto, Inventory>();
            CreateMap<InventoryChangeDto, InventoryChange>();
            CreateMap<InventoryScrapDto, InventoryScrap>();
            CreateMap<MaterialDto, Material>();
            CreateMap<PurchaseDto, Purchase>();
            CreateMap<RepairDto, Repair>();
            CreateMap<RepairDetailDto, RepairDetail>();
            CreateMap<RepairRecordDto, RepairRecord>();
            CreateMap<RequisitionDto, Requisition>();
            CreateMap<RequisitionFeedDto, RequisitionFeed>();
            CreateMap<RequisitionMaterialDto, RequisitionMaterial>();
            CreateMap<RequisitionMedicineDto, RequisitionMedicine>();
            CreateMap<RequisitionThingDto, RequisitionThing>();
            CreateMap<SalesOrderDto, SalesOrder>();
            CreateMap<SalesOrderCheckOutDto, SalesOrderCheckOut>();
            CreateMap<SalesOrderDetailDto, SalesOrderDetail>();
            CreateMap<ThingDto, Thing>();
            CreateMap<VendorDto, Vendor>();
            CreateMap<ReportConfigDto, ReportConfig>();

            CreateMap<PigDiseaseDto, PigDisease>();
            CreateMap<PigCullingDto, PigCulling>();
            CreateMap<PigDiagnosisDto, PigDiagnosis>();
            CreateMap<PigDisease2penDto, PigDisease2pen>();
            CreateMap<PigDisease2pigDto, PigDisease2pig>();
            CreateMap<PigFarmVectorDto, PigFarmVector>();
            CreateMap<PigHouseCleaningDto, PigHouseCleaning>();
            CreateMap<PigHouseCleaning2penDto, PigHouseCleaning2pen>();
            CreateMap<PigHouseCleaning2pigDto, PigHouseCleaning2pig>();
            CreateMap<PigHouseCleaningPlanDto, PigHouseCleaningPlan>();
            CreateMap<PigHouseCleaningRecordDto, PigHouseCleaningRecord>();
            CreateMap<PigHouseCleaningScheduleDto, PigHouseCleaningSchedule>();
            CreateMap<PigFarmVector2penDto, PigFarmVector2pen>();
            CreateMap<PigFarmVector2pigDto, PigFarmVector2pig>();
            CreateMap<PigFarmVectorPlanDto, PigFarmVectorPlan>();
            CreateMap<PigFarmVectorRecordDto, PigFarmVectorRecord>();
            CreateMap<PigFarmVectorScheduleDto, PigFarmVectorSchedule>();

            CreateMap<PigIsolationDto, PigIsolation>();
            CreateMap<PigPrescriptionDto, PigPrescription>();
            CreateMap<PigTreatmentDto, PigTreatment>();
            CreateMap<StoredProcedureDto, StoredProcedure>();
            CreateMap<ChartSettingDto, SysMenu>();
            CreateMap<CodeTypeDto, CodeType>();
            CreateMap<VectorControlDto, VectorControl>();
            CreateMap<DashboardDto, Dashboard>();
            CreateMap<RecordImmunizationDto, RecordImmunization>();
            CreateMap<PigFarmVectorControlDto, PigFarmVectorControl>();
            CreateMap<PigHouseDisinfectionDto, PigHouseDisinfection>();
            CreateMap<BomWeighingDto, BomWeighing>();

            CreateMap<BomFeedingDto, BomFeeding>();
            CreateMap<RfidDto, Rfid>();
            CreateMap<SemenDto, Semen>();
            CreateMap<SemenMixDto, SemenMix>();
            CreateMap<SystemConfigDto, SystemConfig>();
        }

    }
}
