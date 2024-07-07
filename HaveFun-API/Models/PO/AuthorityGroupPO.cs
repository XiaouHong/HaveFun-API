using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 權限群組
/// </summary>
public class AuthorityGroupPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 群組名稱
    /// </summary>
    [MaxLength(30)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 群組英文名稱
    /// </summary>
    [MaxLength(30)]
    public string EnglishName { get; set; } = "";
}
