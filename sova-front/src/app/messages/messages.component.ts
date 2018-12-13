import { Component, OnInit } from '@angular/core';

import { Message } from '../models/message';
import { HubService } from 'app/hub.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss'],
})
export class MessagesComponent implements OnInit {
  public messages: Message[] = [];
  displayedColumns: string[] = ['receiveDate', 'messageType', 'text'];

  constructor(private hub: HubService) {}

  ngOnInit(): void {
    this.messages = this.hub.messages;
  }
}
