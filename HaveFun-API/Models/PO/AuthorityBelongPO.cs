using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 權限群組歸屬
/// </summary>
public class AuthorityBelongPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 群組編號
    /// </summary>
    public int GroupID { get; set; } = 0;

    /// <summary>
    /// 成員編號
    /// </summary>
	public int MemberID { get; set; } = 0;
}
