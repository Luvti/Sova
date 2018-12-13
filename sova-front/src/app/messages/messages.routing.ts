import { Routes, RouterModule } from '@angular/router';
import { MessagesComponent } from './messages.component';

const routes: Routes = [{ path: '', component: MessagesComponent }];

export const MessagesRoutes = RouterModule.forChild(routes);
