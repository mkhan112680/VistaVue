$(document).ready(function () {

    const Scooby = {
        template: `
                        <div>
                          <h4>Scooby</h4>
                          <p>
                            <img src="https://www.wbkidsgo.com/Portals/4/Images/Content/Characters/Scooby/characterArt-scooby-SD.png" alt="scooby"/>
                          </p>
                        </div>`
    }
    const Shaggy = {
        template: `
                        <div class="character">
                            <h4>Shaggy</h4>
                          <p><img src="https://upload.wikimedia.org/wikipedia/en/thumb/8/87/ShaggyRogers.png/150px-ShaggyRogers.png" alt="shaggy"/></p>
                        </div>`
    }

    const MOU = Vue.component('MOU', function (resolve, reject) {
        Vue.http.get('/Physician/MOU', function (data, status, request) {
            //var parser = new DOMParser();
            //var doc = parser.parseFromString(data, "text/html");
            resolve({
                template: data
            });
        });
    });

    const Payee = Vue.component('Payee', function (resolve, reject) {
        Vue.http.get('/Physician/Payee', function (data, status, request) {
            resolve({
                template: data,
                data: function () {
                    return {

                        CheckPayableTo      : '',
                        InternalRefNumber   : '',
                        Address1            : '',
                        Address2            : '',
                        AttentionTo         : '',
                        City                : '',
                        PostalCode          : '',
                        TaxNumber           : '',
                        Instructions        : '',
                        Message             : '',
                        ToCompany           : true,
                        TogglePersonal: function () {
                            this.ToCompany = !this.ToCompany;
                        },
                        ToggleCompany: function () {
                            this.ToCompany = !this.ToCompany;
                        },
                        SavePayee: function () {
                            var mssg = '';
                            //e.preventDefault();
                            $.ajax({
                                type: 'POST',
                                url: $("#btn-save-payee").data("url"),
                                //data:  $('#form-payee-company,#form-payee-personal').serialize()   ,
                                data: {

                                    CheckPayableTo: this.CheckPayableTo,
                                    InternalRefNumber: this.InternalRefNumber,
                                    Address1: this.Address1,
                                    Address2: this.Address2,
                                    AttentionTo: this.AttentionTo,
                                    City: this.City,
                                    PostalCode: this.PostalCode,
                                    TaxNumber: this.TaxNumber,
                                    Instructions: this.Instructions,
                                    Payee_Type: (this.ToCompany ? 1 : 2)
                                   //Province_Company        : '',
                                },
                                success: function (data) {
                                    this.Message = data.Message;                                     //this.$set('Message', data.Message);
                                    //alert(Message);                                 },
                                error: function (jqXHR, textStatus, errorThrown) {

                                    DisplayError(errorThrown);
                                }
                            });
                        }
                    }
                },
            });
        });
    });

    //const Payee = Vue.component('Payee', {
    //    // render function as alternative to 'template'
    //    render: function (createElement) {

    //        $.ajax({
    //            type: 'POST',
    //            url: '/Physician/Payee',
    //            data: {},
    //            success: function (data) {
    //                alert(data);     //                return createElement(
    //                    // {String | Object | Function}
    //                    // An HTML tag name, component options, or function
    //                    // returning one of these. Required.
    //                    'div',
    //                    // {Object}
    //                    // A data object corresponding to the attributes
    //                    // you would use in a template. Optional.
    //                    {
    //                        style: {
    //                            color: 'red',
    //                            fontSize: '28px',
    //                        },
    //                        domProps: {
    //                            innerHTML: data
    //                        }
    //                    },
    //                    // {String | Array}
    //                    // Children VNodes. Optional.
    //                    []
    //                );      //             },
    //            error: function (jqXHR, textStatus, errorThrown) {
    //                DisplayError(errorThrown);
    //            }
    //        });

          
    //    }
    //});

    const router = new VueRouter({
        routes: [
            { path: '/scooby', component: Scooby },
            { path: '/shaggy', component: Shaggy },
            { path: '/MOU', component: MOU },
            { path: '/Payee', component: Payee }
        ]
    });

    const app = new Vue({ router: router }).$mount('.app');

    //app.$refs.Payee.Message = 'hi there';
});