using System;

namespace ChallengePostalCalculator
{
    public partial class _default : System.Web.UI.Page
    {
        private double parcelWidth = 0.00;
        private double parcelHeight = 0.00;
        private double parcelLength = 0.00;
        private double totalPostage = 0.00;

        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                ViewState.Add("parcelWidth", parcelWidth);
                ViewState.Add("parcelHeight", parcelHeight);
                ViewState.Add("parcelLength", parcelLength);
            }
 
        }


     
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtLength.Text.ToString(), out parcelLength);
            ViewState["parcelLength"] = parcelLength;
            GetTotalPostage();
        }
  

        protected void txtWidth_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtWidth.Text.ToString(), out parcelWidth);
            ViewState["parcelWidth"] = parcelWidth;
            GetTotalPostage();
        }

        protected void txtHeight_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtHeight.Text.ToString(), out parcelHeight);
            ViewState["parcelHeight"] = parcelHeight;
            GetTotalPostage();
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        private double CalculateVolume(double dblWidth, double dblHeight)
        {   
            return dblWidth*dblHeight;
        }

        private double CalculateVolume(double dblWidth, double dblHeight, double dblLength)
        {
            return dblWidth * dblHeight * dblLength;
        }

        private double MailingCost(double Volume)
        {
            if (radAir.Checked) return .25 * Volume;
            if (radGround.Checked)
            { return .15 * Volume;
            }
            else
            { return .45 * Volume;
            }
  
        }

        private void GetTotalPostage()
        {
            totalPostage = 0.00;  //Initialize the postage value

            parcelWidth = (double)ViewState["parcelWidth"];
            parcelHeight = (double)ViewState["parcelHeight"];
            parcelLength = (double)ViewState["parcelLength"];

            if (parcelWidth > 0 && parcelHeight > 0 && parcelLength > 0)
            {
                totalPostage = MailingCost(CalculateVolume(parcelWidth, parcelHeight, parcelLength));
            }
            else
            {
                if (parcelHeight > 0 && parcelWidth > 0) totalPostage = MailingCost(CalculateVolume(parcelWidth, parcelHeight));
            }
            if (totalPostage > 0)
            {
                lblPostage.Text =  String.Format("Your parcel will cost {0:C}", totalPostage) + " to ship.";
            }
            else
            {
                lblPostage.Text = "";
            }
        }

        protected void radGround_CheckedChanged(object sender, EventArgs e)
        {
            GetTotalPostage();
        }

        protected void radAir_CheckedChanged(object sender, EventArgs e)
        {
            GetTotalPostage();
        }

        protected void radNextDay_CheckedChanged(object sender, EventArgs e)
        {
            GetTotalPostage();
        }
    }
}