-- BAR CHART ALL
SELECT 
      [Date] AS ClearingDate
      ,COUNT(*) AS ChequeCount
  FROM [dbo].[ChequeDepositInformation]
  GROUP BY [Date]

-- BAR CHART HUB CODE
SELECT 
      [Date] AS ClearingDate
      ,COUNT(*) AS ChequeCount
FROM [dbo].[ChequeDepositInformation]
WHERE HubCode = '0001'
GROUP BY [Date]

-- PIE CHART FOR STATUS
SELECT count(*) AS ChequeCount,
      [status] AS ClearingStatus
  FROM [dbo].[ChequeDepositInformation]
  GROUP BY [Status]

-- REPORT FOR VERIFIED AND RETURNED CHEQUES (SEPARATE)
  SELECT 
      [Date]
      ,[CycleCode]
      ,[CityCode]
	  ,[HubCode]
      ,[serialNo]
      ,[SenderBankCode]            
      ,[ReceiverBranchCode]
      ,[ChequeNumber]
      ,[AccountNumber]            
      ,[Amount]      
      ,[status]
      ,[Returnreasone]
      ,[Error]      
  FROM [dbo].[ChequeDepositInformation]
  WHERE [Status] = 'R'