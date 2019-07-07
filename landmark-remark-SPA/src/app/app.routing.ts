import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RemarkComponent } from './remark/remark.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'remark', component: RemarkComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

export const AppRoutes = RouterModule.forChild(routes);
