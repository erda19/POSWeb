var viewModel = {
    
    ActionForm: actionForm,

    FormData: {

        name: ko.observable("123")
    }
    , Event: {

            Save: function () {

                alert(this.FormData.name());
            }

    }

}

ko.applyBindings(viewModel);
$(function () {

    //viewModel.Event.Save();
    //alert(JSON.stringify(viewModel.ActionForm));
    //alert(actionForm);
    viewModel.FormData.name("123678");
})