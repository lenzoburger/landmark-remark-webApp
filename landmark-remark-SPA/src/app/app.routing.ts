import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RemarkComponent } from './remark/remark.component';

// App Routing module
const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always', // Prevent unauthorized access to whitelisted sites
    canActivate: [AuthGuard],
    children: [
      { path: 'remark', component: RemarkComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }, // redirect *wildcard/unknown routes to home component
];

export const AppRoutes = RouterModule.forChild(routes);
