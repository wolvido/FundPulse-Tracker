﻿
using System.ComponentModel.DataAnnotations;
using BmsKhameleon.Core.Domain.Entities;

namespace BmsKhameleon.Core.DTO.AccountDTOs
{
    public class AccountUpdateRequest
    {
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Account name is required.")]
        [StringLength(50, ErrorMessage = "Account name cannot exceed 50 characters.")]
        public required string AccountName { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(25, ErrorMessage = "Bank name cannot exceed 25 characters.")]
        public required string BankName { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        [StringLength(60, ErrorMessage = "Account number cannot exceed 60 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Account number must be numeric.")]
        public required string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account type is required.")]
        [StringLength(20, ErrorMessage = "Account type cannot exceed 20 characters.")]
        public required string AccountType { get; set; }

        [StringLength(30, ErrorMessage = "Bank branch cannot exceed 30 characters.")]
        public string? BankBranch { get; set; }

        [Required(ErrorMessage = "Initial balance is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Initial balance must be greater than zero.")]
        [DataType(DataType.Currency, ErrorMessage = "must be a valid currency.")]
        public decimal InitialBalance { get; set; }

        [Required(ErrorMessage = "Visibility is required.")]
        public bool Visibility { get; set; }

        public Account ToAccount()
        {
            return new Account
            {
                AccountId = AccountId,
                AccountName = AccountName,
                BankName = BankName,
                AccountNumber = AccountNumber,
                AccountType = AccountType,
                BankBranch = BankBranch,
                InitialBalance = InitialBalance,
                Visibility = Visibility
            };
        }
    }
}