using HaveFun_API.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 權限方法
/// </summary>
public class AuthorityFunctionPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 方法名稱
    /// </summary>
	public string Name { get; set; } = "";

    /// <summary>
    /// 方法英文名稱
    /// </summary>
    public string EnglishName { get; set; } = "";

    /// <summary>
    /// 系統編號
    /// </summary>
    public int SystemID { get; set; } = 0;

    /// <summary>
    /// 權限要求
    /// </summary>
    public AuthorityType AuthorityType { get; set; } = AuthorityType.Unknow;
}
