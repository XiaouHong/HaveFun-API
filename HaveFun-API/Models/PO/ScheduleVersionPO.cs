using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 行程表紀錄
/// </summary>
public class ScheduleVersionPO
{
    /// <summary>
    /// 版本編號
    /// </summary>
    [Key]
    public int VersionID { get; set; } = 0;

    /// <summary>
    /// 計劃編號
    /// </summary>
    public int PlanningID { get; set; } = 0;

    /// <summary>
    /// 行程表編號
    /// </summary>
    public int ScheduleID { get; set; } = 0;

    /// <summary>
    /// 開始時間
    /// </summary>
	public DateTime StartTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 結束時間
    /// </summary>
    public DateTime EndTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 最小花費
    /// </summary>
    public int MinCost { get; set; } = 0;

    /// <summary>
    /// 最大花費
    /// </summary>
	public int MaxCost { get; set; } = 0;

    /// <summary>
    /// 備註
    /// </summary>
	public string Note { get; set; } = "";

    /// <summary>
    /// 景點編號
    /// </summary>
    public int AttractionID { get; set; } = 0;

    /// <summary>
    /// 編輯時間
    /// </summary>
	public DateTime CreatedDate { get; set; } = DateTime.Now;
}
