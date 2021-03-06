export interface RecordFeeding {
  id: number;
  farmGuid: string;
  type: string;
  makeOrderGuid: string;
  pigGuid: string;
  penGuid: string;
  comment: string;
  createDate: string | null;
  createBy: number | null;
  updateDate: string | null;
  updateBy: number | null;
  deleteDate: string | null;
  deleteBy: number | null;
  status: number | null;
  guid: string;
  recordDate: any | null;
  recordTime: string;
  estDate: any | null;
  estTime: string;
  feedGuid: string;
  useType: string;
  useUnit: string;
  frequency: string;
  estAmount: string;
  recordAmount: string;
  recordResult: string;
  typeName: string;
  feedGuidName: string;
  useTypeName: string;
  useUnitName: string;
  recordResultName: string;
  frequencyName: string;
  applyDays: number | null;
}
