export class Oc {
    constructor() {
        this.children = new Array<Oc>();
    }
    key: number;
    levelnumber: number;
    parentid: number;
    state: boolean;
    code: string;
    HasChildren: boolean;
    children: Array<Oc>;
}

export interface OC {
  id: number;
  no: string;
  type: string;
  name: string;
  principal: string;
  length: number;
  level: number;
  width: number;
  longtitude: string;
  latitude: string;
  temptureTopLimit: string;
  temptureLowLimit: string;
  photoPath: string;
  ggp: number;
  gp: number;
  pmpf: number;
  semen: number;
  nursery: number;
  grower: number;
  comment: string;
  parentID: number | null;
  status: boolean | null;
  createBy: number;
  updateBy: number | null;
  deleteBy: number | null;
  createDate: string;
  updateDate: string | null;
  deleteDate: string | null;
  file: any;
}
export class HierarchyNode<T> {
  childNodes: Array<HierarchyNode<T>>;
  depth: number;
  hasChildren: boolean;
  parent: T;
  constructor() {
      this.childNodes = new Array<HierarchyNode<T>>();
  }
  any(): boolean {
      return this.childNodes.length > 0;
  }
}
