using HaveFun_API.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 權限
/// </summary>
public class AuthorityPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 目標類別
    /// </summary>
    public TargetType Type { get; set; } = TargetType.Unknow;

    /// <summary>
    /// 目標編號
    /// </summary>
    public int TargetID { get; set; } = 0;

    /// <summary>
    /// 方法編號
    /// </summary>
    public int FunctionID { get; set; } = 0;

    /// <summary>
    /// 可讀
    /// </summary>
	public bool IsRead { get; set; } = false;

    /// <summary>
    /// 可新增
    /// </summary>
    public bool IsCreate { get; set; } = false;

    /// <summary>
    /// 可更新
    /// </summary>
	public bool IsUpdate { get; set; } = false;

    /// <summary>
    /// 可刪除
    /// </summary>
	public bool IsDelete { get; set; } = false;
}
