import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,Validator, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog'

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  customerForm !: FormGroup
  actionBtn : string = "submit"
  constructor(private formBuilder : FormBuilder, private api : ApiService, 
    @Inject(MAT_DIALOG_DATA) public editData : any,
    private dialogRef: MatDialogRef<DialogComponent>) { }

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group({
      userName : ['',Validators.required],
      email: ['', Validators.required],
      firstName: ['',Validators.required],
      lastName: ['',Validators.required],
      isActive: ['',Validators.required],
      onCreated: [true,Validators.required],
    });

    if(this.editData){
      this.actionBtn = "Update";
      this.customerForm.controls['userName'].setValue(this.editData.userName);
      this.customerForm.controls['email'].setValue(this.editData.email);
      this.customerForm.controls['firstName'].setValue(this.editData.firstName);
      this.customerForm.controls['lastName'].setValue(this.editData.lastName);
      this.customerForm.controls['onCreated'].setValue(this.editData.onCreated)
      this.customerForm.controls['isActive'].setValue(this.editData.isActive);

    }
  }

  addCustomer(){
    if(!this.editData){
      if(this.customerForm.valid){
         this.customerForm.value.onCreated = new Date();

         if(this.customerForm.value.isActive==null ){
          this.customerForm.value.isActive=false;
         }
        
        this.api.postCustomer(this.customerForm.value)
        .subscribe({
          next:(res)=>{
            alert("Customer added Successfully")
            this.customerForm.reset();
            this.dialogRef.close('submit');
          },
          error:()=>{
            alert("Error while adding the Customer")
          }
        })
      }
    }else{
      this.updateCustomer()
    }
  }
  updateCustomer(){
    this.api.putCustomer(this.customerForm.value,this.editData.id)
    .subscribe({
      next:(res)=>{
        alert("Customer Updated Successfully");
        this.customerForm.reset();
        this.dialogRef.close('update')
      },
      error:()=>{
        alert("Error while updating the record!!!")
      }
    })
  }
 

}
