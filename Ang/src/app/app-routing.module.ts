import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: 'app/pages/custom-pages/login/login.module#LoginModule',
  },
  {
    path: 'register',
    loadChildren: 'app/pages/custom-pages/register/register.module#RegisterModule',
  },
  {
    path: 'forgot-password',
    loadChildren: 'app/pages/custom-pages/forgot-password/forgot-password.module#ForgotPasswordModule',
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        loadChildren: 'app/pages/dashboard/dashboard.module#DashboardModule',
        pathMatch: 'full'
      },
      {
        path: 'apps/inbox',
        loadChildren: 'app/pages/apps/inbox/inbox.module#InboxModule',
      },
      {
        path: 'apps/calendar',
        loadChildren: 'app/pages/apps/calendar/calendar.module#CalendarAppModule',
      },
      {
        path: 'apps/chat',
        loadChildren: 'app/pages/apps/chat/chat.module#ChatModule',
      },
      {
        path: 'components',
        loadChildren: 'app/pages/components/components.module#ComponentsModule',
      },
      {
        path: 'forms/form-elements',
        loadChildren: 'app/pages/forms/form-elements/form-elements.module#FormElementsModule',
      },
      {
        path: 'forms/form-wizard',
        loadChildren: 'app/pages/forms/form-wizard/form-wizard.module#FormWizardModule',
      },
      {
        path: 'icons',
        loadChildren: 'app/pages/icons/icons.module#IconsModule',
      },
      {
        path: 'level1/level2/level3/level4/level5',
        loadChildren: 'app/pages/level5/level5.module#Level5Module',
      },
      {
        path: 'maps/google-maps',
        loadChildren: 'app/pages/maps/google-maps/google-maps.module#GoogleMapsModule',
      },
      {
        path: 'tables/simple-table',
        loadChildren: 'app/pages/tables/simple-table/simple-table.module#SimpleTableModule',
      },
      {
        path: 'tables/all-in-one-table',
        loadChildren: 'app/pages/tables/all-in-one-table/all-in-one-table.module#AllInOneTableModule',
      },
      {
        path: 'drag-and-drop',
        loadChildren: 'app/pages/drag-and-drop/drag-and-drop.module#DragAndDropModule'
      },
      {
        path: 'editor',
        loadChildren: 'app/pages/editor/editor.module#EditorModule',
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {
}
