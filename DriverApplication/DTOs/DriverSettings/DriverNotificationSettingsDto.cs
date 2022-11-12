using DriverApplication.DTOs.NotificationsTriggers;
using DriverApplication.DTOs.NotificationsTriggers.AutoAssignTriggersDto;
using DriverApplication.DTOs.NotificationsTriggers.DeliveryTriggersDto;
using DriverApplication.DTOs.NotificationsTriggers.DriverTriggersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverSettings
{
    public class DriverNotificationSettingsDto
    {
        public PickupRequestReceivedTriggerDto pickupRequestReceivedTriggerDto;
        public PickupDriverStartedTriggerDto pickupDriverStartedTriggerDto;
        public PickupDriverArrivedTriggerDto pickupDriverArrivedTriggerDto;
        public PickupSuccessfulTriggerDto pickupSuccessfulTriggerDto;
        public PickupFailedTriggerDto pickupFailedTriggerDto;
        public PickupNotesTriggerDto pickupNotesTriggerDto;
        public PickupPhotoTriggerDto pickupPhotoTriggerDto;
        
        public DeliveryRequestReceivedTriggerDto deliveryRequestReceivedTriggerDto;
        public DeliveryDriverStartedTriggerDto deliveryDriverStartedTriggerDto;
        public DeliveryDriverArrivedTriggerDto deliveryDriverArrivedTriggerDto;
        public DeliverySuccessfulTriggerDto deliverySuccessfulTriggerDto;
        public DeliveryFailedTriggerDto deliveryFailedTriggerDto;
        public DeliveryNotesTriggerDto deliveryNotesTriggerDto;
        public DeliveryPhotoTriggerDto deliveryPhotoTriggerDto;

        public AssignTaskTriggerDto assignTaskTriggerDto;
        public DeletedTaskTriggerDto deletedTaskTriggerDto;
        public NewAddedDriverTriggerDto newAddedDriverTriggerDto;
        public NewSignupWelcomeTriggerDto newSignupWelcomeTriggerDto;
        public SignupApprovedTriggerDto signupApprovedTriggerDto;
        public SignupDeniedTriggerDto signupDeniedTriggerDto;
        public UpdateTaskTriggerDto updateTaskTriggerDto;

        public AutoAssignAcceptedTriggerDto autoAssignAcceptedTriggerDto;
        public FailedAutoAssignTriggerDto failedAutoAssignTriggerDto;



    }
}