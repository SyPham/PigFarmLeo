export interface BOMImmunization {
  id: number;
  bomGuid: string;
  comment: string;
  cancelFlag: string;
  createDate: string | null;
  createBy: number | null;
  updateDate: string | null;
  updateBy: number | null;
  status: number | null;
  guid: string;
  diseaseGuid: string;
  medicineGuid: string;
  useType: string;
  useUnit: string;
  capacity: string;
  frequency: string;
  needle: string;
  applyDays: string;
  disease: string;
  medicine: string;
  useTypeName: string;
  useUnitName: string;
  capacityName: string;
  frequencyName: string;
  needleName: string;
  applyDaysName: string;
}
