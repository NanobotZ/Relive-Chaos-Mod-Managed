using AEChaosModManaged;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ChaosConfigApp
{
    public partial class MainForm : Form
    {
        private readonly ChaosConfig config;

        public MainForm()
        {
            config = new ChaosConfig();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            config.Read();

            // Populate 'Show Voting As' ComboBox
            foreach (var value in Enum.GetValues(typeof(ChaosConfig.ShowVotingType)))
            {
                cbShowVotingAs.Items.Add(value.ToString());
            }

            cbShowVotingAs.SelectedIndex = (int)config.ShowVotingAs;


            nudGlobalEffectDuration.Value = config.GlobalEffectDurationSeconds;
            cbVotingEnabled.Checked = config.IsVotingEnabled;
            gbVotingConfig.Enabled = cbVotingEnabled.Checked;
            cbAllowRandomOption.Checked = config.AllowRandomVoteOption;
            nudMaxVoteOptions.Value = config.MaxOptionsPerVoting;
            tbChannelName.Text = config.TwitchUsername;


            // Populate Effects DataGridView
            var effectType = typeof(BaseEffect);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && !p.IsAbstract && p.IsSubclassOf(effectType));

            foreach (var type in types)
            {
                var instance = (BaseEffect)Activator.CreateInstance(type);
                if (instance.Type != EffectType.Random)
                {
                    if (config.EffectSettings.ContainsKey(instance.Name))
                        dgvEffects.Rows.Add(instance, instance.Name, config.EffectSettings[instance.Name].Weight, config.EffectSettings[instance.Name].DurationModifier);
                    else
                        dgvEffects.Rows.Add(instance, instance.Name, instance.Weight, instance.DurationModifier);
                }
            }
        }

        private void CbVotingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            gbVotingConfig.Enabled = cbVotingEnabled.Checked;
        }

        private void DgvEffects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEffects.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var row = dgvEffects.Rows[e.RowIndex];
                var effectObject = (BaseEffect)row.Cells["EffectObject"].Value;
                row.Cells["ChanceValue"].Value = effectObject.Weight;
                row.Cells["DurationModifierValue"].Value = effectObject.DurationModifier;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            config.GlobalEffectDurationSeconds = (int)nudGlobalEffectDuration.Value;
            config.IsVotingEnabled = cbVotingEnabled.Checked;
            config.ShowVotingAs = (ChaosConfig.ShowVotingType)cbShowVotingAs.SelectedIndex;
            config.AllowRandomVoteOption = cbAllowRandomOption.Checked;
            config.MaxOptionsPerVoting = (int)nudMaxVoteOptions.Value;
            config.TwitchUsername = tbChannelName.Text;
            foreach (DataGridViewRow row in dgvEffects.Rows)
            {
                var effect = (BaseEffect)row.Cells["EffectObject"].Value;
                var chance = (float)row.Cells["ChanceValue"].Value;
                var durationModifier = (float)row.Cells["DurationModifierValue"].Value;

                if (effect.Weight == chance && effect.DurationModifier == durationModifier)
                {
                    if (config.EffectSettings.ContainsKey(effect.Name))
                        config.EffectSettings.Remove(effect.Name);

                    continue;
                }

                if (config.EffectSettings.ContainsKey(effect.Name))
                {
                    config.EffectSettings[effect.Name].Weight = chance;
                    config.EffectSettings[effect.Name].DurationModifier = durationModifier;
                }
                else
                    config.EffectSettings.Add(effect.Name, new ChaosConfig.EffectData { Weight = chance, DurationModifier = durationModifier });
            }
            config.Save();
        }
    }
}
