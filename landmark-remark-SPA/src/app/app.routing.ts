import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RemarkComponent } from './remark/remark.component';
import { MarkerNotesResolver } from './_resolvers/markerNotes-resolver';

// App Routing module
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always', // Prevent unauthorized access to whitelisted sites
    canActivate: [AuthGuard],
    children: [
      {
        path: 'remark',
        component: RemarkComponent,
        resolve: { savedMarkers: MarkerNotesResolver }
      }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' } // redirect *wildcard/unknown routes to home component
];
