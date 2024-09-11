﻿using BmsKhameleon.Core.DTO.TransactionDTOs;
using BmsKhameleon.Core.Enums;
using BmsKhameleon.UI.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BmsKhameleon.UI.Handlers
{
    public class WithdrawCashUpdateTransactionHandler : IUpdateTransactionHandler
    {
        public bool CanHandle(string transactionType, string transactionMedium)
        {
            return transactionType == TransactionType.Withdraw.ToString() && transactionMedium == TransactionMedium.Cash.ToString();
        }

        public IActionResult HandleUpdateTransaction(TransactionResponse transactionResponse)
        {
            var cashTransactionCreateRequest = new CashTransactionCreateRequest
            {
                AccountId = transactionResponse.AccountId,
                TransactionDate = transactionResponse.TransactionDate,
                Amount = transactionResponse.Amount,
                TransactionType = Enum.Parse<TransactionType>(transactionResponse.TransactionType ?? throw new InvalidOperationException("Invalid transaction type")),
                Note = transactionResponse.Note,
                CashTransactionType = transactionResponse.CashTransactionType ?? throw new InvalidOperationException("Cash Transaction Type empty")
            };

            return new PartialViewResult
            {
                ViewName = "~/Views/Shared/TransactionForms/_WithdrawCashTransactionPartial.cshtml",
                ViewData = new ViewDataDictionary<CashTransactionCreateRequest>(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    Model = cashTransactionCreateRequest
                }
            };

        }
    }
}