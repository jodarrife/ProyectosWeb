import { Component, OnInit } from '@angular/core';
import { TaskService } from '../Services/task.service';
import { Task } from '../models/task';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
tasks:Task[];

  constructor(private tasksevice:TaskService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll(){
    this.tasksevice.getAll()
    .subscribe(tasks=>this.tasks=tasks);
  }

}
