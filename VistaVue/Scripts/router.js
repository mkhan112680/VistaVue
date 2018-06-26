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
                        ToCompany: true,
                        ToPersonal: false,
                        TogglePersonal: function () {
                            this.ToPersonal = !this.ToPersonal;
                            this.ToCompany = !this.ToPersonal;
                        },
                        ToggleCompany: function () {
                            this.ToCompany = !this.ToCompany;
                            this.ToPersonal = !this.ToCompany;
                        },
                        SavePayee: function () {

                            //e.preventDefault();
                            console.log('Saved');
                        }
                    }
                },
            });
        });
    });

    const router = new VueRouter({
        routes: [
            { path: '/scooby', component: Scooby },
            { path: '/shaggy', component: Shaggy },
            { path: '/MOU', component: MOU },
            { path: '/Payee', component: Payee }
        ]
    });
    

    const app = new Vue({ router: router }).$mount('.app');
});