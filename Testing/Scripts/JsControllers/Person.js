angular.module('app', ['ngRoute']);

app.controller('TrainingCtrl', function ($scope, $http, toaster, fileUpload) {
    $scope.tabsSeelctedList = [
        {
            "title": "User Details",
            "content": "User Details",
            "tabType": "UserDetails"
        },
        {
            "title": "Account Details",
            "content": "Account Details",
            "tabType": "AccountDetails"
        },
        {
            "title": "Transaction Details",
            "content": "Transaction Details",
            "tabType": "TransactionDetails"
        }
    ];
    $scope.isEdit = false;
    $scope.AccTotalPages = 0;
    $scope.AccCurrentPage = 1;
    $scope.AccPageSize = 10;
    $scope.TotalPages  = 0;
    $scope.CurrentPage  = 1;
    $scope.PageSize = 10;
    $scope.persolList = [];
    $scope.accountsList = [];
    $scope.IsUpdate = false;
    $scope.TransactionCode = 0;
    $scope.isValidPerson = true;
    $scope.tabChanged = function () {
        var tbindex = $scope.tabsSeelctedList.activeTab;
        var tb = $scope.tabsSeelctedList[tbindex];
      
    };

    $scope.SubmmitPerson = function (FirstName, Surname, IDNumber, codes) {
        if (!IDNumber || IDNumber == null) {
            toaster.pop('error', 'FAILED', 'Invalid IDNumber', 6000);
            return;
        }
        $http({
            method: 'POST',
            url: '/Person/InsertPerson',
            data: { firstName: FirstName, surname: Surname, idNumber: IDNumber, code: codes },
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            if (response.data >= 1) {
                toaster.pop('success', 'SUCCESS', 'person details succefully saved', 6000);
                $scope.Clear();
            }
            else {
                toaster.pop('error', 'FAILED', 'person details not saved succefully', 6000);
            }
            $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize, null, null);
        });
    };
    $scope.SubmmitTransaction = function (TransactionDates, Amounts, Descriptions, AccountCodes, transactionsearchinputs, TransactionCodes) {
        var errors = [];
        TransactionCodes = $scope.TransactionCode;
        if (!TransactionDates || TransactionDates == null) errors.push('Transaction Date');
        if (!Amounts || Amounts == null) errors.push('Amount');
        if (!Descriptions || Descriptions == null) errors.push('Description');
        if (!AccountCodes || AccountCodes == null) errors.push('Account number');
        if (Amount == 0) errors.push('Amount can not be zero');
        if (OutsatndingBalance == 0) errors.push('Account closed');
        if (errors.length > 0) {
            toaster.pop('error', 'FAILED', 'Invalid - '+ errors, 6000);
            return;
        }

        var dataToSend = {
            description: Descriptions, amount: Amounts, accountcode: AccountCodes, transactiondate: TransactionDates, transactioncode: TransactionCodes
        };

        $http.post('/Home/InsertTransaction', dataToSend).success(function (response) {
            if (response >= 1) {
                toaster.pop('success', 'SUCCESS', 'account transaction succefully saved', 6000);
                $scope.ClearTransaction();
            }
            else {
                toaster.pop('error', 'FAILED', 'account transaction not saved succefully', 6000);
            }
            $scope.LoadAccountsTransactionList(transactionsearchinputs);
        });
      
    };
    $scope.SubmmitAccount = function (AccountNumber, Balance, codes, accountsearchBy, accountsearchinput, PersonAccountCode) {
        if (!AccountNumber || !Balance) {
            toaster.pop('error', 'FAILED', 'Invalid account details', 6000);
            return;
        }
        $http({
            method: 'POST',
            url: '/Home/InsertAccount',
            data: { accountnumber: AccountNumber, balance: Balance, code: codes, accountcode: PersonAccountCode },
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            if (response.data >= 1) {
                toaster.pop('success', 'SUCCESS', 'Account details succefully saved', 6000);
                $scope.ClearAccount();
            }
            else {
                toaster.pop('error', 'FAILED', 'Account already exist', 6000);
            }
            $scope.loadAccountsList(accountsearchBy,accountsearchinput);
        });
    };

    $scope.DeletePerson = function (codes) {
        if (!codes || codes == null) {
            toaster.pop('error', 'FAILED', 'Invalid person to delete', 6000);
            return;
        }
        $http({
            method: 'POST',
            url: '/Home/DeletePerson',
            data: {  code: codes },
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            if (response.data == 1) {
                toaster.pop('success', 'SUCCESS', 'person details succefully deleted', 6000);
                $scope.Clear();
            }
            else {
                toaster.pop('error', 'FAILED', 'person details is linked to an account', 6000);
            }
            $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize, null, null);
        });
    };

    $scope.LoadData = function (person) {
        $scope.Clear();
        $scope.FirstName = person.name;
        $scope.Surname = person.surname;
        $scope.IDNumber = person.id_number;
        $scope.IsUpdate = true;
        $scope.Code = person.code;
    }
    $scope.LoadTransactionData = function (trans) {
        $scope.TransactionDate = trans.transaction_date;
        $scope.Amount = trans.amount;
        $scope.Description = trans.description;
        $scope.TransactionCode = trans.transaction_code;
        $('#TransactionDate').val(trans.transaction_date);
        $scope.isEdit = true;
    }
    $scope.LoadAccountData = function (account) {
        $scope.isValidPerson = true;
        $scope.AccountNumber = account.account_number;
        $scope.Balance = account.outstanding_balance;
        $scope.PersonAccountCode = account.AccountCode;
    }
    $scope.ClearAccount = function () {
        $scope.AccountNumber = ''; 
        $scope.Balance = '';
        $scope.PersonAccountCode = '';
        $('#PersonAccountCode').val('');
        $('#AccountNumber').val('');
        $('#Balance').val('');
        $scope.accountMainForm = function (form) {

            form.AccountNumber = null;
            form.Balance = null;
            form.PersonAccountCode = null;

        }
    }
    $scope.Clear = function () {
        $scope.FirstName = "";
        $scope.Surname = "";
        $scope.IDNumber = "";
        $scope.IsUpdate = false;
        $scope.Code = "";
        $('#FirstName').val('');
        $('#Surname').val('');
        $('#IDNumber').val('');

        $scope.registerMainForm = function (form) {
            
            form.FirstName = null;
            form.Surname = null;
            form.IDNumber = null;
           
        }

    }


    $scope.ClearTransaction = function () {
        $scope.TransactionDate = '';
        $scope.TransactionAccountNumber = '';
        $scope.Amount = '';
        $scope.Description = '';
        $scope.TransactionFirstName = '';
        $scope.TransactionSurname = '';
        $scope.OutsatndingBalance = '';
        $scope.TransactionIDNumber = '';
        $('#Amount').val('');
        $('#Description').val('');
        $scope.transactionMainForm = function (form) {

            form.Description = null;
            form.Amount = null;
            form.TransactionDate = null;

        }
    }
    $scope.loadPersonsList = function (searchBy, searchinput) {
        if (!searchBy || !searchinput) {
            $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize, null, null);
            return;
        }
           
        if (searchBy == '1' ) {
            $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize, null, searchinput);
        }
        else if (searchBy == '2') {
            $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize, searchinput, null );
        }
    }
    $scope.loadAccountsList = function (searchBy, searchinput) {

        if (searchBy == '1') {
            $scope.GetAllPersonAccountDetails($scope.CurrentPage, $scope.PageSize, null, searchinput);
        }
        else if (searchBy == '2') {
            $scope.GetAllPersonAccountDetails($scope.CurrentPage, $scope.PageSize, searchinput, null);
        }
    }

    $scope.GetAllPersonDetails = function (CurrentPage, PageSize, Surname, IdNumber)
    {
        $http({
            method: 'POST',
            url: '/Home/GetPersonRecords',
            data: { pageNumber: CurrentPage, rowPerPage: PageSize, surname: Surname, idNumber: IdNumber },
            headers: { 'Content-Type': 'application/json' }
        }).then(function (result) {
            $scope.persolList = result.data.List;
            $scope.TotalPages = result.data.TotalPages
        });
    }
    $scope.LoadAccountsTransactionList = function (transactionsearchinput) {
        $scope.isEdit = false;
        $scope.transactionList = [];
        $scope.AccountnCode = '';
        $scope.TransactionCode = '';
        $scope.ClearTransaction();
        $http({
            method: 'POST',
            url: '/Home/GeAccountTransactionRecords',
            data: { accountNumber:  transactionsearchinput},
            headers: { 'Content-Type': 'application/json' }
        }).then(function (result) {
            if (!result.data) {
                toaster.pop('error', 'FAILED', 'No data found', 6000);
                return;
            }
            else {
                $scope.TransactionFirstName = result.data[0].name; 
                $scope.TransactionSurname = result.data[0].surname;
                $scope.OutsatndingBalance = result.data[0].outstanding_balance;
                $scope.TransactionIDNumber = result.data[0].id_number;
                $scope.TransactionAccountNumber = result.data[0].account_number;
                $scope.AccountCode = result.data[0].account_code;
                if (result.data[0].transaction_code == null) {
                    toaster.pop('error', 'FAILED', 'No transaction for account', 6000);
                    return;
                }
                else {
                    $scope.transactionList = result.data;
                }
            }
        });
    }
    $scope.GetAllPersonAccountDetails = function (CurrentPage, PageSize, Accountnumber, IdNumber) {
        $scope.accountsList = [];
        $scope.ClearAccount();
        $http({
            method: 'POST',
            url: '/Home/GetPersonAccountRecords',
            data: { pageNumber: CurrentPage, rowPerPage: PageSize, accountnumber: Accountnumber, idNumber: IdNumber },
            headers: { 'Content-Type': 'application/json' }
        }).then(function (result) { 
            if (!result.data.List) {
                toaster.pop('error', 'FAILED', 'No data found', 6000);
                $scope.isValidPerson = true;
                return;
            }
            else {
                $scope.AccFirstName = result.data.List[0].name;
                $scope.AccIDNumber = result.data.List[0].id_number;
                $scope.AccSurname = result.data.List[0].surname;              
                $scope.TotalPages = result.data.TotalPages;
                $scope.PersonCode = result.data.List[0].code;  
                $scope.isValidPerson = false;
                if (result.data.List[0].account_number == null) {
                    toaster.pop('error', 'FAILED', 'Person is not link to account', 6000);
                    return;
                }
                else {
                    $scope.accountsList = result.data.List;
                }
            }
            
        });
    }

    $scope.GetAllPersonDetails($scope.CurrentPage, $scope.PageSize,null,null);

    //firts page
    $scope.FirstPage = function () {
        $scope.CurrentPage = 1;
        $scope.loadPersonsList($scope.searchBy, $scope.searchinput);
    }

    //go to last page
    $scope.LastPage = function () {
        var lastPageNo = $scope.TotalPages;
        if (lastPageNo > 0) {
            $scope.CurrentPage  = lastPageNo;
            $scope.loadPersonsList($scope.searchBy, $scope.searchinput);
        }
    }

    //next page arrow nav for grid
    $scope.NextPage = function () {
        if ($scope.CurrentPage  < $scope.TotalPages ) {
            var pageValue = $scope.CurrentPage  + 1;
            if (pageValue <= $scope.TotalPages ) {
                $scope.CurrentPage  = pageValue;
                $scope.loadPersonsList($scope.searchBy, $scope.searchinput);
            }
        }
    }

    $scope. PrevPage = function () {
        if ($scope.CurrentPage  > 1) {
            var pageValue = $scope.CurrentPage ;
            $scope.CurrentPage  = pageValue - 1;
            $scope.loadPersonsList($scope.searchBy, $scope.searchinput);
        }
    }

    //firts page
    $scope.AccFirstPage = function () {
        $scope.CurrentPage = 1;
        $scope.loadAccountsList($scope.accountsearchBy, $scope.accountsearchinput);
    }

    //go to last page
    $scope.AccLastPage = function () {
        var lastPageNo = $scope.TotalPages;
        if (lastPageNo > 0) {
            $scope.CurrentPage = lastPageNo;
            $scope.loadAccountsList($scope.accountsearchBy, $scope.accountsearchinput);
        }
    }

    //next page arrow nav for grid
    $scope.AccNextPage = function () {
        if ($scope.CurrentPage < $scope.TotalPages) {
            var pageValue = $scope.CurrentPage + 1;
            if (pageValue <= $scope.TotalPages) {
                $scope.CurrentPage = pageValue;
                $scope.loadAccountsListt($scope.accountsearchBy, $scope.accountsearchinput);
            }
        }
    }

    $scope.AccPrevPage = function () {
        if ($scope.CurrentPage > 1) {
            var pageValue = $scope.CurrentPage;
            $scope.CurrentPage = pageValue - 1;
            $scope.loadAccountsList($scope.accountsearchBy, $scope.accountsearchinput);
        }
    } 
   
    //====== END CONTROLLER ======

});