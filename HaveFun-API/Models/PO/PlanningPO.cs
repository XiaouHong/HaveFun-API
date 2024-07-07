using HaveFun_API.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 計劃
/// </summary>
public class PlanningPO
{
    /// <summary>
    /// 編號
    /// </summary>
    public int ID { get; set; } = 0;

    /// <summary>
    /// 編號
    /// </summary>
    public int TargetID { get; set; } = 0;

    /// <summary>
    /// 目標類別
    /// </summary>
    public TargetType Type { get; set; } = TargetType.Unknow;

    /// <summary>
    /// 備註
    /// </summary>
	public string Note { get; set; } = "";

    /// <summary>
    /// 是否公開
    /// </summary>
    public bool IsPublic { get; set; } = false;

    /// <summary>
    /// 創立時間
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 創立成員
    /// </summary>
    public int CreateUser { get; set; } = 0;
}
