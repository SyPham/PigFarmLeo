﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.DTO
{
    public partial class SysMenuDto
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public decimal? SortId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MenuName { get; set; }
        public string MenuNameCn { get; set; }
        public string MenuNameEn { get; set; }
        public string MenuNameVn { get; set; }
        public string MenuLink { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public decimal? UpperId { get; set; }
        public string MenuLinkEn { get; set; }
        public string MenuLinkCn { get; set; }
        public string MenuIcon { get; set; }
        public string MenuIcon1 { get; set; }
        public string WebPageGuid { get; set; }
        public string WebPageGuidEn { get; set; }
        public string InFooter { get; set; }
        public string InHeader { get; set; }
        public string StoredProceduresName { get; set; }
        public string ReportType { get; set; }
        public string ChartName { get; set; }
        public string ChartNameEn { get; set; }
        public string ChartNameVn { get; set; }
        public string ChartNameCn { get; set; }
        public string ChartUnit { get; set; }

        public string ChartXAxisName { get; set; }
        public string ChartXAxisNameEn { get; set; }
        public string ChartXAxisNameVn { get; set; }
        public string ChartXAxisNameCn { get; set; }

        public string ChartYAxisName { get; set; }
        public string ChartYAxisNameEn { get; set; }
        public string ChartYAxisNameVn { get; set; }
        public string ChartYAxisNameCn { get; set; }

        public decimal? FarmGgp { get; set; }
        public decimal? FarmGp { get; set; }
        public decimal? FarmPmpf { get; set; }
        public decimal? FarmSemen { get; set; }
        public decimal? FarmNursery { get; set; }
        public decimal? FarmGrower { get; set; }
    }
    public partial class ChartSettingDto
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string MenuLink { get; set; }
        public string ReportType { get; set; }
        public string ChartName { get; set; }
        public string ChartNameEn { get; set; }
        public string ChartNameVn { get; set; }
        public string ChartNameCn { get; set; }
        public string ChartUnit { get; set; }

        public string Guid { get; set; }

        public string ChartXAxisName { get; set; }
        public string ChartXAxisNameEn { get; set; }
        public string ChartXAxisNameVn { get; set; }
        public string ChartXAxisNameCn { get; set; }

        public string ChartYAxisName { get; set; }
        public string ChartYAxisNameEn { get; set; }
        public string ChartYAxisNameVn { get; set; }
        public string ChartYAxisNameCn { get; set; }
    }
  
    public partial class DataSourceChartDto
    {
        public object dataSource { get; set; }

    }
     public partial class ReportParams
    {
        public DateTime D1 { get; set; }
        public DateTime D2 { get; set; }
        public string Keyword { get; set; }
        public string Sort { get; set; }
        public string Sort2 { get; set; }
        public string MenuLink { get; set; }
        public string FarmGuid { get; set; }
        public string RoomGuid1 { get; set; }
        public string RoomGuid2 { get; set; }
        public string MakeOrderGuid1 { get; set; }
        public string MakeOrderGuid2 { get; set; }

    }
    public partial class ChartDataDto
    {
        public string type { get; set; }
        public string xName { get; set; }
        public string yName { get; set; }
        public string colorName { get; set; }
        public string legend { get; set; }

    }

}
