import { NgModule } from '@angular/core';

import { MessagesComponent } from './messages.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MessagesRoutes } from './messages.routing';

@NgModule({
  imports: [CommonModule, FormsModule, MessagesRoutes],
  declarations: [MessagesComponent],
})
export class MessagesModule {}
